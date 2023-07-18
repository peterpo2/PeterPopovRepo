using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Reply> Replies { get; set; } 
        public List<Like> Likes { get; set; } = new List<Like>();
        public bool IsDeleted { get; set; } 

    }
}
