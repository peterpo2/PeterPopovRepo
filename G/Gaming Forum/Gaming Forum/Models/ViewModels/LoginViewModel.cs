using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
		[StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters.")]
		public string Username { get; set; }

        [Required]
		[StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
		public string Password { get; set; }
    }
}
