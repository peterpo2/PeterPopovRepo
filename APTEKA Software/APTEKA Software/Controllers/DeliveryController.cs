using APTEKA_Software.Helpers;
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
            var deliveryViewModels = mapper.Map<List<DeliveryViewModel>>(deliveries);

            foreach (var deliveryViewModel in deliveryViewModels)
            {
                var user = userService.GetUser(deliveryViewModel.UserId);
                var item = itemService.GetItemById(deliveryViewModel.ItemId);

                deliveryViewModel.UserName = $"{user.FirstName} {user.LastName}";
                deliveryViewModel.ItemName = item.ItemName;
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

            var deliveryDto = new DeliveryDto();

            var items = itemService.GetAllItems();
            if (items != null)
            {
                deliveryDto.Items = items.Select(item => new SelectListItem
                {
                    Value = item.ItemId.ToString(),
                    Text = item.ItemName
                }).ToList();
            }

            deliveryDto.DeliveryDate = DateTime.Now;

            return this.View(deliveryDto);
        }

        [HttpPost]
        public IActionResult MakeDelivery(DeliveryDto deliveryDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(deliveryDto);
            }

            deliveryDto.DeliveryDate = DateTime.Now;
            
            var userIdClaim = this.authManager.CurrentUser;

            if (userIdClaim != null)
            {
                int currentUserId = userIdClaim.UserId;
                deliveryDto.UserId = currentUserId;

                this.deliveryService.CreateDelivery(deliveryDto);

            }

            else
            {
                throw new Exception("shit");
            }

            return this.RedirectToAction("Index");
        }
    }
}
