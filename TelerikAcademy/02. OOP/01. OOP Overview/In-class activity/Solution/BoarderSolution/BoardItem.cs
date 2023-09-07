using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoarderSolution
{
    public class BoardItem
    {
        const string DateFormat = "dd-MM-yyyy";

        public string title;
        public DateTime dueDate;
        public Status status;

        public BoardItem(string title, DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Please provide non-empty title.");
            }

            if (title.Length < 5 || title.Length > 30)
            {
                throw new ArgumentException("Please provide title between 5 and 30 symbols.");
            }

            if (dueDate < DateTime.Now)
            {
                throw new ArgumentException("Due date can't be in the past.");
            }

            this.title = title;
            this.dueDate = dueDate;
            this.status = Status.Open;
        }

        public void RevertStatus()
        {
            if (this.status != Status.Open)
            {
                this.status--;
            }
        }

        public void AdvanceStatus()
        {
            if (this.status != Status.Verified)
            {
                this.status++;
            }
        }

        public string ViewInfo()
        {
            return $"'{title}', [{status}|{dueDate.ToString(DateFormat)}]";
        }
    }
}
