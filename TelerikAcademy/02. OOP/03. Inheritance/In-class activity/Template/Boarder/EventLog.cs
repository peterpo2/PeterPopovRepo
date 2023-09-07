using System;
using System.Collections.Generic;
using System.Text;

namespace Boarder
{
    public class EventLog
    {
        public EventLog(string description)
        {
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Time = DateTime.Now;
        }

        public string Description { get; }

        public DateTime Time { get; }

        public string ViewInfo()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{this.Description}";
        }
    }
}
