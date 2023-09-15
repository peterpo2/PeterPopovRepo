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

            var saleDto = new SaleDto();

            var items = itemService.GetAllItems();
            if (items != null)
            {
                saleDto.Items = items.Select(item => new SelectListItem
                {
                    Value = item.ItemId.ToString(),
                    Text = item.ItemName
                }).ToList();
            }

            saleDto.DeliveryDate = DateTime.Now;

            return this.View(saleDto);
        }

        [HttpPost]
        public IActionResult MakeSale(SaleDto saleDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(saleDto);
            }

            saleDto.DeliveryDate = DateTime.Now;

            var userIdClaim = this.authManager.CurrentUser;

            if (userIdClaim != null)
            {
                int currentUserId = userIdClaim.UserId;
                saleDto.UserId = currentUserId;

                this.salesService.CreateSale(saleDto);

            }

            else
            {
                throw new Exception("shit");
            }

            return this.RedirectToAction("Index");
        }
    }
}
