using System;
using System.Drawing;

namespace WorkingHour.Assets
{
    public static class StaticAssets
    {
        /// <summary>
        /// زمان شروع
        /// </summary>
        public static DateTime Start { get; set; }

        public static bool AddSecondToDuration { get; set; }
        public static TimeSpan Duration { get; set; }

        public static Point LatestCursorPosition { get; set; }
        public static TimeSpan LatestCursorPositionChangeTime { get; set; }
    }
}
