using System;

namespace WorkingHour.Data.Models
{
    public class TimeModel
    {
        public Guid Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}
