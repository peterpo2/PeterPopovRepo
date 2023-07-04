using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.Dto
{
    public class CommentResponseDto
    {
        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
        public string? CreatedBy { get; set; }
        public int? Likes { get; set; }
        public string? PostTitle { get; set; }
        
    }
}
