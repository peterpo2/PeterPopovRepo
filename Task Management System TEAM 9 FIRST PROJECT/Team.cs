using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class Team
    {
        public string Name { get; set; }
        public List<TeamMember> Members { get; set; }

        public Team(string name)
        {
            Name = name;
            Members = new List<TeamMember>();
        }

        public void AddMember(TeamMember member)
        {
            Members.Add(member);
        }

        public void AssignBugsToMember(TeamMember member, BugSeverity severity)
        {
            foreach (var bug in GetAllBugsWithSeverity(severity))
            {
                bug.AssignedTo = member.Name;
                member.Bugs.Add(bug);
            }
        }

        private List<Bug> GetAllBugsWithSeverity(BugSeverity severity)
        {
            // TODO: retrieve all bugs with specified severity
            return new List<Bug>();
        }
    }
}