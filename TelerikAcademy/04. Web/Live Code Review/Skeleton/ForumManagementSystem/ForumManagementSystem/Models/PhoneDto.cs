
using System.ComponentModel.DataAnnotations;

namespace ForumManagementSystem.Models
{
    public class PhoneDto
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
