using System;
using MD.PersianDateTime;

namespace WorkingHour.Data.Models
{
    public class TimeModel
    {
        public Guid Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public TimeSpan Duration { get; set; }
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

        private PersianDateTime _startPersianDateTime;
        public PersianDateTime StartPersianDateTime
        {
            get
            {
                if (_startPersianDateTime > PersianDateTime.MinValue) return _startPersianDateTime;
                _startPersianDateTime = new PersianDateTime(RegisterDateTime) { EnglishNumber = true };
                return _startPersianDateTime;
            }
        }

        private PersianDateTime _stopPersianDateTime;
        public PersianDateTime StopPersianDateTime
        {
            get
            {
                if (_stopPersianDateTime > PersianDateTime.MinValue) return _stopPersianDateTime;
                _stopPersianDateTime = new PersianDateTime(RegisterDateTime) { EnglishNumber = true };
                return _stopPersianDateTime;
            }
        }
    }
}
