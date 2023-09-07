using System.Collections.Generic;

namespace AspNetCoreDemo.Models.DTO
{
    public class BeerResponseDto
    {
        public string Name { get; set; }
        public double Abv { get; set; }
        public string Style { get; set; }
        public string Creator { get; set; }
        public double AvgRating { get; set; }
        public Dictionary<string, int> Ratings { get; set; } = new Dictionary<string, int>();
    }
}
