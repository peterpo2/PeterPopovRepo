namespace APTEKA_Software.Models.ViewModels
{
    public class UserDetailViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<DeliveryViewModel> Deliveries { get; set; }
        public List<SaleViewModel> Sales { get; set; }
    }
}
