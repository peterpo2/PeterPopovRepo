namespace Gaming_Forum.Models
{
    public class SearchQueryParameters
    {
        public string Query { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public string SortBy { get; set; }

        public string TagValue { get; set; }


        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
    }
}
