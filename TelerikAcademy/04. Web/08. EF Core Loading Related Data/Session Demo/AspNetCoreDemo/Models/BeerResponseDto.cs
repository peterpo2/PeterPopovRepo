using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreDemo.Models
{
    public class BeerResponseDto
    {
        public BeerResponseDto(Beer beerModel)
        {
            Name = beerModel.Name;
            Abv = beerModel.Abv;
            Style = beerModel.Style.Name;
            Creator = beerModel.CreatedBy.Username;

            AvgRating = beerModel.Ratings.Average(rating => rating.Value);

            foreach (var rating in beerModel.Ratings)
            {
                Ratings.Add(rating.User.Username, rating.Value);
            }
        }

        public string Name { get; set; }
        public double Abv { get; set; }
        public string Style { get; set; }
        public string Creator { get; set; }
        public double AvgRating { get; set; }
        public Dictionary<string, int> Ratings { get; set; } = new Dictionary<string, int>();
    }
}
