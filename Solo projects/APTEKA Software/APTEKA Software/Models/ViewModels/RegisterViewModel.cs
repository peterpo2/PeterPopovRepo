using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }
    }
}
