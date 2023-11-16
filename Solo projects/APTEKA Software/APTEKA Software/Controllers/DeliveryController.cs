using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService deliveryService;
        private readonly IItemService itemService;
        private readonly AuthManager authManager;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public DeliveryController(IDeliveryService deliveryService, IItemService itemService, AuthManager authManager, IUserService userService, IMapper mapper)
        {
            this.deliveryService = deliveryService;
            this.itemService = itemService;
            this.authManager = authManager;
            this.userService = userService;
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
                deliveryViewModel.ItemName = item.ItemName;

                deliveryViewModel.DeliverySum = item.SalePrice * deliveryViewModel.QuantityDelivered;

                deliveryViewModels.Add(deliveryViewModel);
            }

            return View(deliveryViewModels);
        }

        [HttpGet]
        public IActionResult MakeDelivery(int Id)
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
            ItemViewModel itemViewModel = mapper.Map<ItemViewModel>(item);

            return View(itemViewModel);
        }

        [HttpPost]
        public IActionResult MakeDelivery(int id, ItemViewModel itemViewModel)
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
                Item updatedItem = mapper.Map<Item>(itemViewModel);

                int remainingQuantity = deliveryService.GetRemainingQuantity(id);
                int newAvailableQuantity = remainingQuantity + itemViewModel.QuantityDelivered;

                var item = itemService.GetItemById(id);
                item.AvailableQuantity = newAvailableQuantity;
                itemService.UpdateItem(id, item);
                this.deliveryService.CreateDelivery(itemViewModel, id);
            }
            else
            {
                throw new Exception("shit");
            }

            return RedirectToAction("Index", "Delivery");
        }
    }
}
