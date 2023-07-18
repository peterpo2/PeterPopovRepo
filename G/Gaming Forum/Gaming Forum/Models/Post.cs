using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "Title is empty.")]
        [StringLength(64, MinimumLength = 16, ErrorMessage = "Title must be between 16 and 64 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is empty.")]
        [StringLength(8192, MinimumLength = 32, ErrorMessage = "Content must be between 32 and 8192 characters.")]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Comment> Comments { get; set; } 
        public List<Reply> Replies { get; set; } 
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Like> Likes { get; set; } 
        public bool IsDeleted { get; set; }


    }
}
