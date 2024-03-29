﻿using APTEKA_Software.Data;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;

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
    }
}
