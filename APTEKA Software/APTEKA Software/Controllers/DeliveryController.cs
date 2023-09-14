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
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService deliveryService;
        private readonly IUserService userService;
        private readonly IItemService itemService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;

        public DeliveryController(IDeliveryService deliveryService, IUserService userService, IItemService itemService, AuthManager authManager,IMapper mapper)
        {
            this.deliveryService = deliveryService;
            this.userService = userService;
            this.itemService = itemService;
            this.authManager = authManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var deliveries = deliveryService.GetAllDeliveries();
            var deliveryViewModels = new List<DeliveryViewModel>();

            var mapper = HttpContext.RequestServices.GetService<IMapper>();

            foreach (var delivery in deliveries)
            {
                var deliveryViewModel = mapper.Map<Delivery, DeliveryViewModel>(delivery);

                var user = userService.GetUser(delivery.UserId);
                var item = itemService.GetItemById(delivery.ItemId);

                deliveryViewModel.UserName = $"{user.FirstName} {user.LastName}";
                deliveryViewModel.ItemName = item.Name;

                deliveryViewModels.Add(deliveryViewModel);
            }

            return View(deliveryViewModels);
        }

        [HttpGet]
        public IActionResult MakeDelivery()
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction("Login", "Users");
            }

            var viewModel = new DeliveryViewModel();

            var items = itemService.GetAllItems();
            viewModel.AvailableItems = items.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult MakeDelivery(DeliveryViewModel viewModel)
        {
            try
            {
                if (this.authManager.CurrentUser == null)
                {
                    return this.RedirectToAction("Login", "Users");
                }

                if (!this.ModelState.IsValid)
                {
                    viewModel.AvailableItems = itemService.GetAllItems()
                        .Select(item => new SelectListItem
                        {
                            Text = item.Name,
                            Value = item.Id.ToString()
                        }).ToList();

                    return this.View(viewModel);
                }

                var user = this.authManager.CurrentUser;
                var deliveryDto = new DeliveryDto
                {
                    ItemId = viewModel.ItemId,
                    QuantityDelivered = viewModel.QuantityDelivered,
                    DeliveryDate = DateTime.Now
                };

                var deliveryResult = deliveryService.MakeDelivery(deliveryDto, user, viewModel.ItemId);

                return this.RedirectToAction("Deliveries", new { id = deliveryResult.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
