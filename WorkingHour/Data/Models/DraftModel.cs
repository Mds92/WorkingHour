using System;

namespace WorkingHour.Data.Models
{
    public class DraftModel
    {
        public DraftModel()
        {
            StartDateTime = DateTime.MinValue;
            StopDateTime = DateTime.MinValue;
            Duration = TimeSpan.MinValue;
        }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
