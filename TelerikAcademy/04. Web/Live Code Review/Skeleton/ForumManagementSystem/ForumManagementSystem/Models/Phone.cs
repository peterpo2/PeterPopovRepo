namespace ForumManagementSystem.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int OwnerId { get; set; }
        public User? Owner { get; set; }
    }
}
