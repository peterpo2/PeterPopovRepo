using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class Comment
    {
        public string Message { get; set; }
        public TeamMember Author { get; set; }
        // other properties and methods for comments
    }

    // ...

    //var newComment = new Comment
    //{
    //    Message = "This one took me a while, but it is fixed now!",
    //    Author = developer
    //};

    //task.Comments.Add(newComment);
}
