namespace Gaming_Forum.Models.Dto
{
    public class UserResponseDto
    {

        public string Username { get; set; }

        public List<CommentResponseDto> Comments { get; set; }

        public List<PostUserResponseDto> Posts { get; set; }

        public List<LikeResponseDto> Likes { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
