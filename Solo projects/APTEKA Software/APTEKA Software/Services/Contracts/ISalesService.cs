﻿using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Services.Contracts
{
    public interface ISalesService
    {
        List<Sale> GetAllSales();
        SaleResult MakeSale(int userId, int itemId, int quantity);
        int GetRemainingQuantity(int itemId);
        List<Sale> GetSalesByUserId(int userId);
        void CreateSale(int itemId, int quantitySold);
        //void CreateSale(SaleViewModel saleViewModel);  
        //void CreateSale(ItemViewModel itemViewModel, int itemId);
        List<SaleViewModel> GetSaleViewModelsByUserId(int userId);
    }
}
