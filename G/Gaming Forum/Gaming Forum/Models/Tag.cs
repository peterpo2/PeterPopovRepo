namespace Gaming_Forum.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<Post> Posts { get; set; } 

    }
}
