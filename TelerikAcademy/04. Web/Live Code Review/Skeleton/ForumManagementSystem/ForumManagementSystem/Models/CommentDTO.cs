using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ForumManagementSystem.Models
{
    // TODO Add DTOs to a package.
    public class CommentDTO
    {
        [Required]
        [MaxLength(8192, ErrorMessage = "Content should be between 4 and 32 symbols")]
        public string Content { get; set; }

        public int postId { get; set; }
    }
}
