using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
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

        public SalesController(ISalesService salesService, IItemService itemService, AuthManager authManager, IUserService userService)
        {
            this.salesService = salesService;
            this.itemService = itemService;
            this.authManager = authManager;
            this.userService = userService;
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
                saleViewModel.ItemName = item.Name;

                saleViewModels.Add(saleViewModel);
            }

            return View(saleViewModels);
        }

        [HttpGet]
        public IActionResult MakeSale()
        {
            var viewModel = new SaleViewModel();

            var items = itemService.GetAllItems();
            viewModel.AvailableItems = items.Select(item => new SelectListItem
            {
                Text = $"{item.Name} (Цена: {item.SalePrice:C})",
                Value = item.Id.ToString()
            }).ToList();

            viewModel.SaleItems = new List<SaleItemViewModel>();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeSale(SaleViewModel viewModel)
        {

            var selectedItem = itemService.GetItemById(viewModel.ItemId);

            var saleItemViewModel = new SaleItemViewModel
            {
                ItemName = selectedItem.Name,
                Quantity = viewModel.QuantitySold,
                SalePrice = selectedItem.SalePrice,
                TotalPrice = viewModel.QuantitySold * selectedItem.SalePrice
            };

            viewModel.SaleItems ??= new List<SaleItemViewModel>();
            viewModel.SaleItems.Add(saleItemViewModel);

            viewModel.TotalAmount = viewModel.SaleItems.Sum(item => item.TotalPrice);

            var userId = this.authManager.CurrentUser.Id;
            var saleResult = salesService.MakeSale(userId, viewModel.ItemId, viewModel.QuantitySold);

            if (saleResult.Success)
            {
                return RedirectToAction("SaleConfirmation", new { totalSaleValue = viewModel.TotalAmount });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "The sale could not be completed.");
                return View(viewModel);
            }
        }
    }
}
