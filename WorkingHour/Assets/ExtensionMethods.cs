using System;
using System.Collections.Generic;
using System.Text;
using MD.PersianDateTime;

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
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToStandardString(this PersianDateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd   HH:mm:ss");
        }

        public static string ToStandardString<T>(this IEnumerable<T> queue)
        {
            var stringBuilder = new StringBuilder("");
            foreach (var item in queue)
                stringBuilder.Append(item);
            return stringBuilder.ToString();
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
