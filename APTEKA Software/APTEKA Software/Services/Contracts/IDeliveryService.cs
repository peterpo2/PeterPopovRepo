using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Services.Contracts
{
    public interface IDeliveryService
    {
        List<Delivery> GetAllDeliveries();
        DeliveryResult MakeDelivery(DeliveryDto deliveryDto, User user, int itemId);
        int GetRemainingQuantity(int itemId);
        List<Delivery> GetDeliveriesForUser(int userId);
        Delivery GetDeliveryById(int id);
        //void AddDelivery(Delivery delivery);
        //void UpdateDelivery(Delivery delivery);
        //void DeleteDelivery(int id);
    }
}
