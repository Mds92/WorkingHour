using System;

namespace WorkingHour.Assets
{
    public static class ExtensionMethods
    {
        public static string ToStandardString(this TimeSpan timeSpan)
        {
            var totalHours = Math.Floor(timeSpan.TotalHours);
            return $"{totalHours:0000}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

        public static string ToStandardString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public static TimeSpan StandardTimeSpanParse(this string inputString)
        {
            if(string.IsNullOrWhiteSpace(inputString)) return TimeSpan.MinValue;
            var arr = inputString.Split(':');
            int.TryParse(arr[0], out var hour);
            int.TryParse(arr[1], out var minute);
            int.TryParse(arr[2], out var second);
            return TimeSpan.FromSeconds(hour * 60 * 60 + minute * 60 + second);
        }
    }
}
