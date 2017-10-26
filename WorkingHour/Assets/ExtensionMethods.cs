using System;

namespace WorkingHour.Assets
{
    public static class ExtensionMethods
    {
        public static string ToStandardString(this TimeSpan timeSpan)
        {
            return $"{timeSpan.TotalHours:0000}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

        public static string ToStandardString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }

        public static TimeSpan StandardTimeSpanParse(this string inputString)
        {
            var arr = inputString.Split(':');
            int.TryParse(arr[0], out int hour);
            int.TryParse(arr[1], out int minute);
            int.TryParse(arr[2], out int second);
            return TimeSpan.FromSeconds(hour * 60 * 60 + minute * 60 + second);
        }
    }
}
