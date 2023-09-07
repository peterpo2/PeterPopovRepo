using System.ComponentModel.DataAnnotations;

namespace ForumManagementSystem.Models
{
    public class Post
    {
        public Post()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [Range(8, 64, ErrorMessage = "{0} should be between {1} and {2} symbols")]
        public string Title { get; set; }

        [Required]
        [Range(16, 8192, ErrorMessage = "{0} should be between {1} and {2} symbols")]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; } = new();
        public List<Tag> Tags { get; } = new();
    }
}
