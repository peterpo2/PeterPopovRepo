namespace ForumManagementSystem.Models
{
    public class Comment
    {
        public Comment()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int? AuthorId { get; set; }
        public User Author { get; set; }
    }
}
