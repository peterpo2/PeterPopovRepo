using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDemo.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
