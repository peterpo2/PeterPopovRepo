using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_System.Enums;

namespace Task_Management_System
{
    public class BugTracker
    {
        public List<Bug> Bugs { get; set; }
        public List<Team> Teams { get; set; }

        public BugTracker()
        {
            Bugs = new List<Bug>();
            Teams = new List<Team>();
        }

        public void AddBug(Bug bug)
        {
            Bugs.Add(bug);
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        // TODO: implement other functionality as needed
    }

}
