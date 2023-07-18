using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.ViewModels
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "Title is empty.")]
        [StringLength(64, MinimumLength = 16, ErrorMessage = "Title must be between 16 and 64 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
    }
}
