using System;

namespace WorkingHour.Data.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan TotalDuration { get; set; }
    }
}
