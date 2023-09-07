using System;

namespace Boarder.Models
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate, Status.Open)
        {
            this.Description = description ?? "No desciption";

            this.AddEventLog($"Created Issue: {this.ViewInfo()}. Description: {this.Description}");
        }

        public string Description { get; }
    }
}
