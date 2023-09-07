using System;

namespace Boarder
{
    public class EventLog
    {
        public EventLog(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Description cannot be null or empty!");
            }

            this.Description = description;
            this.Time = DateTime.Now;
        }

        // When a property has only get; means that it is read-only i.e. can be set only once in the constructor.
        public string Description
        {
            get;
        }

        public DateTime Time
        {
            get;
        }

        public string ViewInfo()
        {
            string timeAsString = $"{this.Time:yyyyMMdd|HH:mm:ss.ffff}";
            return $"[{timeAsString}] {this.Description}";
        }
    }
}
