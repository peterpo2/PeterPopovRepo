using APTEKA_Software.Models;
using System.ComponentModel.DataAnnotations;

public class UserViewModel
{
    public int UserId { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters.")]
    public string Username { get; set; }

    [Required]
    [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
    public string LastName { get; set; }

    public DateTime DateRegistered { get; set; }
    public List<Delivery> Deliveries { get; set; } = new List<Delivery>(); // Initialize to avoid null issues
    public List<Sale> Sales { get; set; } = new List<Sale>(); // Initialize to avoid null issues

    public int SalesCount => Sales.Count;
    public int DeliveriesCount => Deliveries.Count;
}
