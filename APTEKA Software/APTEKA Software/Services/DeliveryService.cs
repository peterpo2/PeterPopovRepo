using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IUserService userService;

        public DeliveryService(IDeliveryRepository deliveryRepository, IUserService userService)
        {
            this.deliveryRepository = deliveryRepository;
            this.userService = userService;
        }

        public void CreateDelivery(DeliveryDto deliveryDto)
        {
            var user = userService.GetUser(deliveryDto.UserId);

            var delivery = new Delivery
            {
                UserId = user.UserId,
                ItemId = deliveryDto.ItemId,
                DeliveryDate = deliveryDto.DeliveryDate,
                QuantityDelivered = deliveryDto.QuantityDelivered
            };

            deliveryRepository.MakeDelivery(delivery);
        }

        public List<Delivery> GetAllDeliveries()
        {
            return this.deliveryRepository.GetAllDeliveries();
        }
    }
}
