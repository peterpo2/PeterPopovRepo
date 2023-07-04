namespace Gaming_Forum.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int? CommentId { get; set; }
        public Comment Comment { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
        public bool IsDeleted { get; set; }
    }
}
