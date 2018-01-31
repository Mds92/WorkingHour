using System;
using System.Collections.Generic;
using System.Drawing;

namespace WorkingHour.Assets
{
    public static class StaticAssets
    {
        /// <summary>
        /// زمان شروع
        /// </summary>
        public static DateTime StartDateTime { get; set; }
        public static DateTime StopDateTime { get; set; }

        public static TimeSpan Duration { get; set; }

        public static TimeSpan IdleTime { get; set; }
        public static Point LatestCursorPosition { get; set; }

        public static Size OriginalWindowSize { get; set; }

        public static readonly List<string> ForbiddinApps = new List<string>
        {
            "Telegram",
            "دیجی کالا",
            "تابناک",
            "تسنیم",
            "فارس",
            "presstv",
            "باشگاه خبرنگاران",
            "دنیای اقتصاد"
        };
    }
}
