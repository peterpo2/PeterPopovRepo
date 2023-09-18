using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Repositories;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IUserService userService;
        private readonly IItemService itemService;
        private readonly IItemRepository itemRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository, IUserService userService,IItemService itemService, IItemRepository itemRepository)
        {
            this.deliveryRepository = deliveryRepository;
            this.userService = userService;
            this.itemService = itemService;
            this.itemRepository = itemRepository;
        }

        public void CreateDelivery(ItemViewModel itemViewModel,int itemId)
        {
            var item = itemService.GetItemById(itemId);
            var user = userService.GetUser(itemViewModel.UserId);

            if (item == null || item.AvailableQuantity < itemViewModel.QuantitySold)
            {
                throw new Exception("Артикулът не е наличен или няма достатъчно количество за продажба.");
            }

            var delivery = new Delivery
            {
                UserId = user.UserId,
                ItemId = itemId,
                DeliveryDate = DateTime.Now,
                QuantityDelivered = itemViewModel.QuantityDelivered,
                TotalAmount = itemViewModel.QuantityDelivered * item.SalePrice
            };
            deliveryRepository.MakeDelivery(delivery);
            item.AvailableQuantity += itemViewModel.QuantityDelivered;
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
        public List<Delivery> GetAllDeliveries()
        {
            return this.deliveryRepository.GetAllDeliveries();
        }
        //API CONTROLLER
        public DeliveryResult MakeDelivery(int userId, int itemId, int quantityDelivered)
        {
            var item = itemService.GetItemById(itemId);
            var user = userService.GetUser(userId);

            if (item == null || item.AvailableQuantity < quantityDelivered)
            {
                throw new Exception("Артикулът не е наличен или няма достатъчно количество за доставка.");
            }

            var delivery = new Delivery
            {
                UserId = user.UserId,
                ItemId = itemId,
                DeliveryDate = DateTime.Now,
                QuantityDelivered = quantityDelivered,
            };
            deliveryRepository.MakeDelivery(delivery);

            var deliverySum = item.SalePrice * quantityDelivered;

            item.AvailableQuantity += quantityDelivered;
            itemService.UpdateItem(itemId, item);

            var deliveryResult = new DeliveryResult
            {
                Success = true,
                QuantityDelivered = quantityDelivered,
                NewAvailableQuantity = item.AvailableQuantity,
                Id = delivery.DeliveryId,
                ItemId = delivery.ItemId,
                RemainingQuantity = GetRemainingQuantity(itemId),
                Quantity = delivery.QuantityDelivered,
                DeliveryDate = delivery.DeliveryDate,
                DeliverySum = deliverySum
            };

            return deliveryResult;
        }
    }
}
