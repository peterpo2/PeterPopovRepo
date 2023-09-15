using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APTEKA_Software.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService salesService;
        private readonly IItemService itemService;
        private readonly AuthManager authManager;
        private readonly IUserService userService;
        private readonly IMapper modelMapper;

        public SalesController(ISalesService salesService, IItemService itemService, AuthManager authManager, IUserService userService, IMapper modelMapper)
        {
            this.salesService = salesService;
            this.itemService = itemService;
            this.authManager = authManager;
            this.userService = userService;
            this.modelMapper = modelMapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sales = salesService.GetAllSales();
            var saleViewModels = new List<SaleViewModel>();

            var mapper = HttpContext.RequestServices.GetService<IMapper>();

            foreach (var sale in sales)
            {
                var saleViewModel = mapper.Map<Sale, SaleViewModel>(sale);

                var user = userService.GetUser(sale.UserId);
                var item = itemService.GetItemById(sale.ItemId);

                saleViewModel.UserName = $"{user.FirstName} {user.LastName}";
                saleViewModel.ItemName = item.ItemName;

                saleViewModels.Add(saleViewModel);
            }

            return View(saleViewModels);
        }

        [HttpGet]
        public IActionResult MakeSale(int Id)
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction("Login", "Users");
            }
            Item item = itemService.GetItemById(Id);

            if (item == null)
            {
                return NotFound();
            }
            ItemViewModel itemViewModel = modelMapper.Map<ItemViewModel>(item);
            //var itemViewModel = new ItemViewModel
            //{
            //    ItemId = item.ItemId,
            //    ItemName = item.ItemName,
            //    AvailableQuantity = item.AvailableQuantity,
            //    SalePrice = item.SalePrice
            //};

            return View(itemViewModel);
        }

        [HttpPost]
        public IActionResult MakeSale(int id,ItemViewModel itemViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(itemViewModel);
            }
            var userIdClaim = this.authManager.CurrentUser;
            if (userIdClaim != null)
            {
                int currentUserId = userIdClaim.UserId;
                itemViewModel.UserId = currentUserId;
                Item updatedItem = modelMapper.Map<Item>(itemViewModel);

                int remainingQuantity = salesService.GetRemainingQuantity(id);
                int newAvailableQuantity = remainingQuantity - itemViewModel.QuantitySold;

                var item = itemService.GetItemById(id);
                item.AvailableQuantity = newAvailableQuantity;
                itemService.UpdateItem(id,item);
                this.salesService.CreateSale(itemViewModel,id);
            }
            else
            {
                throw new Exception("shit");
            }

            return RedirectToAction("Index", "Sales");
        }
    }
}
