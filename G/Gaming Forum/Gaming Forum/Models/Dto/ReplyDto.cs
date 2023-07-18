namespace Gaming_Forum.Models.Dto
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
