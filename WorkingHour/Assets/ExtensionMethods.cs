using System;

namespace WorkingHour.Assets
{
    public static class ExtensionMethods
    {
        public static string ToStandardString(this TimeSpan timeSpan)
        {
            return timeSpan.ToString("c");
        }

        public static string ToStandardString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd  hh:mm:ss");
        }
    }
}
