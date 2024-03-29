﻿using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class DeliveryViewModel
    {
        public int DeliveryId { get; set; }
        public int UserViewModelId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
        public decimal DeliverySum { get; set; }
        //public decimal TotalAmount { get; set; }
    }
}
