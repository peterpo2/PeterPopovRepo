using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gaming_Forum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters.")]
        // TODO: Add a regular expression for valid username format
        public string Username { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
    ErrorMessage = "Please enter a valid email address.")]
        // TODO: Add uniqueness validation
        public string? Email { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }

        // Optional property
        public string? PhoneNumber { get; set; }


        public bool IsAdmin { get; set; }

        public bool IsBlocked { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Post> Posts { get; set; } 

        public List<Like> Likes { get; set; } 

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsLoggedIn { get; set; }
    }
}
