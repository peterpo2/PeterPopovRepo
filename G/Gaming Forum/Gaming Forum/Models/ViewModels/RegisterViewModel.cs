using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$",
    ErrorMessage = "Please enter a valid email address.")]
        // TODO: Add uniqueness validation
        public string Email { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }
    }
}
