using APTEKA_Software.Models;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface ISaleRepository
    {
        Sale Create(Sale sale);
        List<Sale> GetAll();
    }
}
