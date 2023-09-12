using APTEKA_Software.Models;

namespace APTEKA_Software.Services.Contracts
{
    public interface ISalesService
    {
        List<Sale> GetAllSales();
        SaleResult MakeSale(int userId, int itemId, int quantity);
        int GetRemainingQuantity(int itemId);
    }
}
