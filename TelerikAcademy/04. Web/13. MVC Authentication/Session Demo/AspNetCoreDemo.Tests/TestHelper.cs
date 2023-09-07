using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Tests.Services
{
    public class TestHelper
    {
        public static Beer GetTestBeer()
        {
            return new Beer
            {
                Id = 1,
                Name = "Test Beer 1",
                Abv = 4.6,
                StyleId = 1,
                CreatedById = 2,
            };
        }

        public static User GetTestUser()
        {
            return new User
            {
                Id = 1,
                Username = "Test User 1",
                IsAdmin = false
            };
        }

        public static List<Style> GetTestStyles()
        {
            return new List<Style>
            {
                new Style
                {
                    Id = 1,
                    Name = "Test Style 1"
                },
                new Style
                {
                    Id = 2,
                    Name = "Test Style 2"
                },
                new Style
                {
                    Id = 3,
                    Name = "Test Style 3"
                }
            };
        }

        public static List<Beer> GetTestBeers()
        {
            return new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    Name = "Test Beer 1",
                    Abv = 4.6,
                    StyleId = 1,
                    CreatedById = 2
                },
                new Beer
                {
                    Id = 2,
                    Name = "Test Beer 2",
                    Abv = 5.0,
                    CreatedById = 2,
                    StyleId = 2
                },
                new Beer
                {
                    Id = 3,
                    Name = "Test Beer 3",
                    Abv = 6.6,
                    CreatedById = 3,
                    StyleId = 3
                }
            };
        }

        public static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Test User 1",
                    IsAdmin = false
                },
                new User
                {
                    Id = 2,
                    Username = "Test User 2",
                    IsAdmin = false
                },
                new User
                {
                    Id = 3,
                    Username = "Test Admin 1",
                    IsAdmin = true
                }
            };
        }

        public static List<Rating> GetTestRatings()
        {
            return new List<Rating>
            {
                new Rating() { Id = 1, BeerId = 1, UserId = 3, Value = 5 },
                new Rating() { Id = 2, BeerId = 1, UserId = 2, Value = 2 },
                new Rating() { Id = 3, BeerId = 2, UserId = 3, Value = 1 },
                new Rating() { Id = 4, BeerId = 2, UserId = 2, Value = 3 },
                new Rating() { Id = 5, BeerId = 3, UserId = 3, Value = 5 },
                new Rating() { Id = 6, BeerId = 3, UserId = 2, Value = 5 }
            };
        }
    }
}
