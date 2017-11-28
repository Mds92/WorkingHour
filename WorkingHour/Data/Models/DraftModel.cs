using System;

namespace WorkingHour.Data.Models
{
    public class DraftModel
    {
        public DraftModel()
        {
            StartDateTime = DateTime.MinValue;
            Duration = TimeSpan.MinValue;
        }
        public DateTime StartDateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
