using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class TeamMember
    {
        public string Name { get; set; }
        public List<Bug> Bugs { get; set; }

        public TeamMember(string name)
        {
            Name = name;
            Bugs = new List<Bug>();
        }
    }
}
