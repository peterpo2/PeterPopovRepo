using APTEKA_Software.Models;

namespace APTEKA_Software.Services.Contracts
{
    public interface ISalesService
    {
        SaleResult MakeSale(int userId, int itemId, int quantity);
    }
}
