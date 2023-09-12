using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Services
{
    public class SalesService : ISalesService
    {
        private readonly IItemRepository itemRepository;
        private readonly IUserRepository userRepository;
        private readonly ISaleRepository saleRepository;

        public SalesService(IItemRepository itemRepository, IUserRepository userRepository, ISaleRepository saleRepository)
        {
            this.itemRepository = itemRepository;
            this.userRepository = userRepository;
            this.saleRepository = saleRepository;
        }
        public List<Sale> GetAllSales()
        {
            return this.saleRepository.GetAll();
        }
        public SaleResult MakeSale(int userId, int itemId, int quantity)
        {
            var user = userRepository.GetUser(userId);
            var item = itemRepository.GetById(itemId);

            if (user != null && item != null)
            {
                if (item.AvailableQuantity >= quantity)
                {
                    var totalSaleValue = quantity * item.SalePrice;

                    if (item.AvailableQuantity >= quantity)
                    {
                        item.AvailableQuantity -= quantity;

                        itemRepository.Update(item);

                        return new SaleResult
                        {
                            Success = true,
                            TotalSaleValue = totalSaleValue,
                            RemainingQuantity = item.AvailableQuantity 
                        };
                    }
                    else
                    {
                        throw new EntityNotFoundException($"Недостатъчно количество на артикула {item.Name}.");
                    }
                }
                else
                {
                    throw new EntityNotFoundException($"Недостатъчно количество на артикула {item.Name}.");
                }
            }
            else
            {
                throw new EntityNotFoundException($"Невалиден потребител ({user}) или артикул ({item}).");
            }
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

    }
}
