using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boarder
{
    public class BoardItem
    {
        private const Status InitialStatus = Status.Open;
        private const Status FinalStatus = Status.Verified;
        private const string DateFormat = "dd-MM-yyyy";

        private DateTime dueDate;
        private string title;
        private readonly List<EventLog> history;

        public BoardItem(string title, DateTime dueDate)
        {
            this.history = new List<EventLog>();

            this.EnsureValidDate(dueDate);
            this.dueDate = dueDate;

            //this.EnsureValidTitle(title);
            this.Title = title;

            this.Status = InitialStatus;

            this.AddEventLog($"Item created: {this.ViewInfo()}");
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.EnsureValidTitle(value);
                if (this.title != null) 
                {
                    this.AddEventLog($"Title changed from '{this.title}' to '{value}'");
                }

                this.title = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.EnsureValidDate(value);
                this.AddEventLog($"DueDate changed from '{this.dueDate.ToString(DateFormat)}' to '{value.ToString(DateFormat)}'");

                this.dueDate = value;
            }
        }

        // This is known as an 'auto-implemented' property.
        public Status Status
        {
            // public getter means that the 'Status' property can be accessed from anywhere
            // both from this class (BoardItem) class as well as the 'outside' world (static void Main in Program.cs)
            get;
            // private setter means that the 'Status' property can be accessed only withing this class (BoardItem)
            private set;
        }

        public void RevertStatus()
        {
            if (this.Status != InitialStatus)
            {
                var prevStatus = this.Status;
                this.Status--;

                this.AddEventLog($"Status changed from {prevStatus} to {this.Status}");
            }
            else
            {
                this.AddEventLog($"Can't revert, already at {InitialStatus}");
            }
        }

        public void AdvanceStatus()
        {
            if (this.Status != FinalStatus)
            {
                var prevStatus = this.Status;
                this.Status++;

                this.AddEventLog($"Status changed from {prevStatus} to {this.Status}");
            }
            else
            {
                this.AddEventLog($"Can't advance, already at {FinalStatus}");
            }
        }

        public string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{this.DueDate.ToString(DateFormat)}]";
        }

        public string ViewHistory()
        {
            StringBuilder result = new StringBuilder();
            foreach (EventLog entry in this.history)
            {
                result.AppendLine(entry.ViewInfo());
            }
            return result.ToString();
        }

        private void AddEventLog(string desc)
        {
            this.history.Add(new EventLog(desc));
        }

        private void EnsureValidDate(DateTime value)
        {
            if (value < DateTime.Now)
            {
                throw new ArgumentException("DueDate can't be in the past");
            }
        }

        private void EnsureValidTitle(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Please provide a non-empty name");
            }

            if (value.Length < 5 || value.Length > 30)
            {
                throw new ArgumentException("Please provide a name with length between 5 and 30 chars");
            }
        }
    }
}
