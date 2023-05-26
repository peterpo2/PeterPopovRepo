using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Enums;

namespace Task_Management_System
{
    public class Feedback : Task
    {
        public int Rating { get; set; }
        public Status Status { get; set; }
        // other specific properties and methods for feedbacks
    }
}
