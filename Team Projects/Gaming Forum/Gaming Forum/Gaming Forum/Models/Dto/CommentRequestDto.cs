using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.Dto
{
    public class CommentRequestDto
    {
        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
    }
}
