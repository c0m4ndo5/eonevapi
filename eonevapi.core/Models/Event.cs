using System;
using System.Collections.Generic;

namespace eonevapi.core.Models
{
    public class Event
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public DateTime closed { get; set; }
        public ICollection<Category> categories { get; set; }
        public ICollection<Source> sources { get; set; }
        public ICollection<Geometry> geometries { get; set; }
    }
}