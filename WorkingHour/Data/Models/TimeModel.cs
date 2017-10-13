using System;

namespace WorkingHour.Data.Models
{
    public class TimeModel
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime RegisterDateTime { get; set; }
    }
}
