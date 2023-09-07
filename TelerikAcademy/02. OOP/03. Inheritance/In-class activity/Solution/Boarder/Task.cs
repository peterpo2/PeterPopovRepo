using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder
{
    public class Task : BoardItem
    {
        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate, Status.ToDo)
        {
            Assignee = assignee;
            this.AddEventLog($"Created task: {this.ViewInfo()}, Assignee: {Assignee}");
        }

        public string Assignee
        {
            get
            {
                return this.assignee;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Assignee cannot be null or empty");
                }

                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Assignee must be between 5 and 30 symbols");
                }

                if (this.assignee != null)
                {
                    this.AddEventLog($"Assignee changed from {this.assignee} to {value}");
                }

                this.assignee = value;
            }
        }

        
    }
}
