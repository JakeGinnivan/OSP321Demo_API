using System;

namespace TechEdDemoApi.Representations
{
    public class TimeSheetRepresentation
    {
        public EngagementRepresentation Engagement { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
    }
}