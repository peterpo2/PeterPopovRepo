using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    public class TaskManager
    {
        public List<Team> Teams { get; set; }
        // methods for creating and managing teams, members, boards, tasks, etc.
        public void AddMemberToTeam(TeamMember member, Team team)
        {
            team.Members.Add(member);
            team.ActivityHistory.Add($"{member.Name} was added to the team {team.Name}.");
        }
        // other methods for manipulating the data
    }
}
