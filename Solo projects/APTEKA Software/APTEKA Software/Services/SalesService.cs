﻿using APTEKA_Software.Exeptions;
using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class SalesService : ISalesService
    {
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IUserService userService;
        private readonly IItemService itemService;
        private readonly AuthManager authManager;

        public SalesService(IItemRepository itemRepository, IUserRepository userRepository, ISaleRepository saleRepository, IUserService userService, IItemService itemService, AuthManager authManager)
        {
            this.itemRepository = itemRepository;
            this.userRepository = userRepository;
            this.saleRepository = saleRepository;
            this.userService = userService;
            this.itemService = itemService;
            this.authManager = authManager;
        }
        public List<Sale> GetAllSales()
        {
            return this.saleRepository.GetAll();
        }

        //API CONTROLLER
        public SaleResult MakeSale(int userId, int itemId, int quantity)
        {
            var user = userRepository.GetUser(userId);
            var item = itemRepository.GetById(itemId);

            if (user == null || item == null)
            {
                throw new EntityNotFoundException($"Невалиден потребител ({user}) или артикул ({item}).");
            }

            if (item.AvailableQuantity < quantity)
            {
                throw new EntityNotFoundException($"Недостатъчно количество на артикула {item.ItemName}.");

            }

            var totalSaleValue = quantity * item.SalePrice;
            item.AvailableQuantity -= quantity;

            itemRepository.Update(item);

            return new SaleResult
            {
                Success = true,
                TotalSaleValue = totalSaleValue,
                RemainingQuantity = item.AvailableQuantity
            };
        }

        //RAZOR PAGES CONTROLLER
        // public void CreateSale(ItemViewModel itemViewModel, int itemId)
        // {
        //     var item = itemService.GetItemById(itemId);
        //     var user = userService.GetUser(itemViewModel.UserId);
        //
        //     if (item == null || item.AvailableQuantity < //itemViewModel.QuantitySold)
        //     {
        //         throw new Exception("Артикулът не е наличен или няма //достатъчно количество за продажба.");
        //     }
        //
        //     var sale = new Sale
        //     {
        //         UserId = user.UserId,
        //         ItemId = itemId,
        //         SaleDate = DateTime.Now,
        //         QuantitySold = itemViewModel.QuantitySold,
        //         TotalAmount = itemViewModel.QuantitySold * item.SalePrice
        //     };
        //
        //     saleRepository.MakeSale(sale);
        //     item.AvailableQuantity -= itemViewModel.QuantitySold;
        // }
        public void CreateSale(int itemId, int quantitySold)
        {
            var item = itemService.GetItemById(itemId);
            var user = userService.GetUser(authManager.CurrentUser.UserId);

            if (item == null || item.AvailableQuantity < quantitySold)
            {
                throw new Exception("Артикулът не е наличен или няма достатъчно количество за продажба.");
            }

            var sale = new Sale
            {
                UserId = user.UserId,
                ItemId = itemId,
                SaleDate = DateTime.Now,
                QuantitySold = quantitySold,
                TotalAmount = quantitySold * item.SalePrice
            };

            saleRepository.MakeSale(sale);
            item.AvailableQuantity -= quantitySold;
            itemRepository.Update(item);
        }

        public int GetRemainingQuantity(int itemId)
        {
            var item = itemRepository.GetById(itemId);

            if (item != null)
            {
                return item.AvailableQuantity;
            }
            else
            {
                throw new EntityNotFoundException($"Артикул с идентификационен номер {itemId} не беше намерен.");
            }
        }
        public List<Sale> GetSalesByUserId(int id)
        {
            return this.saleRepository.GetAll()
                                      .Where(sale => sale.UserId == id)
                                      .ToList();
        }
        public List<SaleViewModel> GetSaleViewModelsByUserId(int id)
        {
            List<Sale> sales = GetSalesByUserId(id);

            List<SaleViewModel> saleViewModels = sales.Select(sale => new SaleViewModel
            {
                UserName = userService.GetUser(sale.UserId)?.Username,
                ItemName = itemService.GetItemById(sale.ItemId)?.ItemName,
                SaleDate = sale.SaleDate,
                QuantitySold = sale.QuantitySold,
                TotalAmount = sale.TotalAmount
            }).ToList();

            return saleViewModels;
        }
    }
}
