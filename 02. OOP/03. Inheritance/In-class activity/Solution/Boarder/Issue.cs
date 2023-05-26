using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            Description = description ?? "No description";

            this.AddEventLog($"Issue created: {this.ViewInfo()}, Description: {Description}");
        }
        public string Description { get; }
    }
}
