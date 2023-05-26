using System.Drawing;
using Task_Management_System.Enums;

namespace Task_Management_System
{
    public class Story : Task
    {
        public System.Drawing.Size Size { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public TeamMember Assignee { get; set; }
        // other specific properties and methods for stories
    }
}
