﻿using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 32 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "First name must be between 4 and 32 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Last name must be between 4 and 32 characters.")]
        public string LastName { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public ICollection<Delivery> Deliveries { get; set; }

    }
}
