using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System.Contracts
{
    public interface IBugTracker
    {
        void CreateBug(Bug bug);
        void AssignBug(Bug bug, Developer developer);
        List<Bug> GetAllBugs();
    }
}
