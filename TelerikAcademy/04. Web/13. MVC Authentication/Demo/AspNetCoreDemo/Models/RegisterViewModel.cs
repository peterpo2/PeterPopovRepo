using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
