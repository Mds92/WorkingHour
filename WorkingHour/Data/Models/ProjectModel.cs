using System;
using MD.PersianDateTime;

namespace WorkingHour.Data.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan InitialDuration { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public DateTime RegisterDateTime { get; set; }

        private PersianDateTime _registerPersianDateTime;
        public PersianDateTime RegisterPersianDateTime
        {
            get
            {
                if (_registerPersianDateTime > PersianDateTime.MinValue) return _registerPersianDateTime;
                _registerPersianDateTime = new PersianDateTime(RegisterDateTime) { EnglishNumber = true };
                return _registerPersianDateTime;
            }
        }
    }
}
