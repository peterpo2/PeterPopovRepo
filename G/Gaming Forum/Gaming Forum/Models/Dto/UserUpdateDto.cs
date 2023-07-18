using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.Dto
{
    public class UserUpdateDto
    {
        

        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string? Password { get; set; }

		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
			ErrorMessage = "Please enter a valid email address.")]
		public string? Email { get; set; }


        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string? FirstName { get; set; }

        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }

        // Optional property
        public string? PhoneNumber { get; set; }
    }
}
