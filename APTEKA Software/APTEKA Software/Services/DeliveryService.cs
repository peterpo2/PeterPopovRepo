using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IUserRepository userRepository;
        private readonly IItemRepository itemRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this.deliveryRepository = deliveryRepository;
            this.userRepository = userRepository;
            this.itemRepository = itemRepository;
        }
        public List<Delivery> GetAllDeliveries()
        {
            return deliveryRepository.GetAllDeliveries();

        }

        public Delivery GetDeliveryById(int id)
        {
            return deliveryRepository.GetDeliveryById(id);
        }

        public List<Delivery> GetDeliveriesForUser(int userId)
        {
            var deliveries = deliveryRepository.GetDeliveriesByUserId(userId);
            return deliveries;
        }

        public DeliveryResult MakeDelivery(DeliveryDto deliveryDto, User user, int itemId)
        {
            var item = itemRepository.GetById(itemId);

            var delivery = new Delivery
            {
                UserId = user.Id,
                ItemId = deliveryDto.ItemId,
                DeliveryDate = deliveryDto.DeliveryDate,
                QuantityDelivered = deliveryDto.QuantityDelivered
            };

            var newDelivery = deliveryRepository.MakeDelivery(delivery);

            item.AvailableQuantity += deliveryDto.QuantityDelivered;
            itemRepository.Update(item);

            return new DeliveryResult
            {
                Success = true,
                QuantityDelivered = deliveryDto.QuantityDelivered,
                NewAvailableQuantity = item.AvailableQuantity,
                Id = newDelivery.DeliveryId,
                ItemId = deliveryDto.ItemId,
                RemainingQuantity = item.AvailableQuantity,
                Quantity = deliveryDto.QuantityDelivered,
                DeliveryDate = deliveryDto.DeliveryDate,
                Item = item,
                User = user
            };
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