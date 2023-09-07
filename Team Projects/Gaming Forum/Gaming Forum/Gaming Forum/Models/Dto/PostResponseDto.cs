using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models.Dto
{
    public class PostResponseDto
    {
        
        public User User { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<CommentResponseDto> Comments { get; set; }
        public List<PostResponseDto> Replies { get; set; }
        public List<string> Tags { get; set; }
        public int Likes { get; set; }
        
    }
}
