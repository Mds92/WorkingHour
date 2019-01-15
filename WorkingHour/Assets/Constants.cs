using System;

namespace WorkingHour.Assets
{
    public static class Constants
    {
        public static TimeSpan MinTimeSpanToIdentifyIdle = new TimeSpan(0, 0, 5, 0);
        public static readonly string RootNodeName = "Database";
        public static readonly string ProjectsNodeName = "Projects";
        public static readonly string ProjectNodeName = "Project";
        public static readonly string TimesNodeName = "Times";
        public static readonly string TimeNodeName = "Time";
    }
}
