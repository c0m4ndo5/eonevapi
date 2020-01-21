using System;

namespace eonevapi.api.Resources
{
    public class EventResource
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public DateTime? closed { get; set; }
        public int categoryId { get; set; }
        public DateTime? lastGeometryDate { get; set; }
        public double lastGeometryX { get; set; }
        public double lastGeometryY { get; set; }
    }
}