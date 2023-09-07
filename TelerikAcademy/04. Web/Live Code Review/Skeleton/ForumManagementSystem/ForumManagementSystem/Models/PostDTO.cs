using System.ComponentModel.DataAnnotations;

namespace ForumManagementSystem.Models
{
    public class PostDTO
    {
        [Required]
        [Range(8, 64, ErrorMessage = "{0} should be between {1} and {2} symbols")]
        public string Title { get; set; }

        [Required]
        [Range(16, 8192, ErrorMessage = "{0} should be between {1} and {2} symbols")]
        public string Content { get; set; }
    }
}
