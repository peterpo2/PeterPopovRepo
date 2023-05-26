using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class Board
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
        public List<string> ActivityHistory { get; set; }
        // other properties and methods for boards
    }

    // ...

    //var newBoard = new Board
    //{
    //    Name = "Board A",
    //    Tasks = new List<Task>(),
    //    ActivityHistory = new List<string>()
    //}
}
