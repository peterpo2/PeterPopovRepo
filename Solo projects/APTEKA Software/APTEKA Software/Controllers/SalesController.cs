using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

            foreach (var sale in sales)
            {
                var saleViewModel = modelMapper.Map<Sale, SaleViewModel>(sale);

                var user = userService.GetUser(sale.UserId);
                var item = itemService.GetItemById(sale.ItemId);

                saleViewModel.UserName = $"{user.FirstName} {user.LastName}";
                saleViewModel.ItemName = item.ItemName;

                saleViewModels.Add(saleViewModel);
            }

            return View(saleViewModels);
        }

        [HttpGet]
        public IActionResult MakeSale()
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction("Login", "Users");
            }

            var items = itemService.GetAllItems();
            var itemViewModels = items.Select(item => modelMapper.Map<ItemViewModel>(item)).ToList();

            var saleViewModel = new SaleViewModel
            {
                Items = itemViewModels // Ensure this list is not null
            };

            return View(saleViewModel);
        }

        [HttpPost]
        public IActionResult MakeSale(SaleViewModel saleViewModel, List<AddedItemViewModel> addedItems)
        {
            if (!ModelState.IsValid)
            {
                return View(saleViewModel);
            }

            var userIdClaim = this.authManager.CurrentUser;
            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Users");
            }

            try
            {
                // Process each added item
                foreach (var item in addedItems)
                {
                    salesService.CreateSale(item.ItemId, item.QuantitySold);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(saleViewModel);
            }

            return RedirectToAction("Index", "Sales");
        }
    }
}
