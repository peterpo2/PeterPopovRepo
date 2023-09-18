using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Services.Contracts
{
    public interface IDeliveryService
    {
        void CreateDelivery(ItemViewModel itemViewModel, int itemId);
        List<Delivery> GetAllDeliveries();
        int GetRemainingQuantity(int itemId);
        DeliveryResult MakeDelivery(int userId, int itemId, int quantityDelivered);
    }
}
