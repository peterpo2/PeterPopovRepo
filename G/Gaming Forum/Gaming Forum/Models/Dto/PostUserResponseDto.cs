namespace Gaming_Forum.Models.Dto
{
    public class PostUserResponseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<CommentResponseDto> Comments { get; set; }
        public List<ReplyResponseDto> Replies { get; set; }
        public int Likes { get; set; }

    }
}
