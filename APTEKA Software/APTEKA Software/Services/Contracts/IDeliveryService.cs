using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Services.Contracts
{
    public interface IDeliveryService
    {
        void CreateDelivery(DeliveryDto deliveryDto);
        List<Delivery> GetAllDeliveries();
        //void AddDelivery(Delivery delivery);
        //void UpdateDelivery(Delivery delivery);
        //void DeleteDelivery(int id);
    }
}
