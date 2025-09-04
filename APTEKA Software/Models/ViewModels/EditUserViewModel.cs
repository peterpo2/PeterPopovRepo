using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }
    }

}
