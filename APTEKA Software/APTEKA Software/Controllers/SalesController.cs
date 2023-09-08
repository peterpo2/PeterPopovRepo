using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APTEKA_Software.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService salesService;
        private readonly IItemService itemService;

        public SalesController(ISalesService salesService, IItemService itemService)
        {
            this.salesService = salesService;
            this.itemService = itemService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MakeSale()
        {
            var viewModel = new SaleViewModel();

            var items = itemService.GetAllItems();
            viewModel.AvailableItems = items.Select(item => new SelectListItem
            {
                Text = $"{item.Name} (Продажна цена: {item.SalePrice})",
                Value = item.Id.ToString()
            }).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeSale(SaleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var items = itemService.GetAllItems();
                viewModel.AvailableItems = items.Select(item => new SelectListItem
                {
                    Text = $"{item.Name} (Продажна цена: {item.SalePrice})",
                    Value = item.Id.ToString()
                }).ToList();

                return View(viewModel);
            }

            return RedirectToAction("MakeSale");
        }

    }
}
