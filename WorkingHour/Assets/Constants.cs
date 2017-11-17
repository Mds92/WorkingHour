using System;

namespace WorkingHour.Assets
{
    public static class Constants
    {
        public static TimeSpan MinTimeSpanToIdentifyIdle = new TimeSpan(0, 0, 1, 0);
        public static string ProjectsNodeName = "Projects";
        public static string ProjectNodeName = "Project";
        public static string TimesNodeName = "Times";
        public static string TimeNodeName = "Time";
    }
}
