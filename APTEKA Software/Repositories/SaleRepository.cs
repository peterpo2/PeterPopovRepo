using APTEKA_Software.Data;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APTEKA_Software.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationContext context;

        public SaleRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void MakeSale(Sale sale)
        {
            context.Sale.Add(sale);
            context.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            return context.Sale.ToList();
        }
        public void ReassignSales(int oldUserId, int newUserId)
        {
            var sales = context.Sale.Where(s => s.UserId == oldUserId).ToList();

            foreach (var sale in sales)
            {
                sale.UserId = newUserId;
            }

            context.SaveChanges();
        }

        public bool HasSales(int userId)
        {
            return context.Sale.Any(s => s.UserId == userId);
        }

    }
}
