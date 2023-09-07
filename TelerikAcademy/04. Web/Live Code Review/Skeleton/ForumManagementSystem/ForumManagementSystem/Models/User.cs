﻿namespace ForumManagementSystem.Models
{
    public class User
    {
        public User()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime Date { get; set; }

        public Phone? Phone { get; set; }

        public List<Post> Posts { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();

    }
}