using APTEKA_Software.Models;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface ISaleRepository
    {
        List<Sale> GetAll();
        void MakeSale(Sale sale);
    }
}
