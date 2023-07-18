using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Like> Likes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
