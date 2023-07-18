namespace Gaming_Forum.Models.Dto
{
    public class LikeResponseDto
    {
        public PostResponseDto Post { get; set; }
        public CommentResponseDto Comment { get; set; }
        public ReplyResponseDto Reply { get; set; }

    }
}
