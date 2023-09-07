using System;
using System.Collections.Generic;
using System.Linq;

namespace Boarder
{
    public class BoardItem
    {
        private readonly Status initialStatus;
        private const Status FinalStatus = Status.Verified;
        private const string DateFormat = "dd-MM-yyyy";

        private DateTime dueDate;
        private string title;
        private readonly List<EventLog> history = new List<EventLog>();

        protected BoardItem(string title, DateTime dueDate, Status initialStatus)
        {
            this.EnsureValidDate(dueDate);
            this.EnsureValidTitle(title);

            this.title = title;
            this.dueDate = dueDate;
            this.Status = initialStatus;
            this.initialStatus = initialStatus;
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
                this.AddEventLog($"Title changed from '{this.title}' to '{value}'");

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

        public Status Status { get; private set; }

        public void RevertStatus()
        {
            if (this.Status != initialStatus)
            {
                var prevStatus = this.Status;
                this.Status--;

                this.AddEventLog($"Status changed from {prevStatus} to {this.Status}");
            }
            else
            {
                this.AddEventLog($"Can't revert, already at {initialStatus}");
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
            return string.Join(Environment.NewLine, this.history.Select(e => e.ViewInfo()));
        }

        protected void AddEventLog(string desc)
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
