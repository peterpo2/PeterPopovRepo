namespace Gaming_Forum.Models
{
    public class PostQueryParameters
    {
        public string? Title { get; set; }
        public string? User { get; set; }
        public string? Content { get; set; }
        public List<string>? Tags { get; set; }

        public bool SortByLikesDescending { get; set; }
        public bool SortByLikesAscending { get; set; }
                
    }
}
