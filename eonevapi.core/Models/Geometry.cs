using System;
using System.Collections.Generic;

namespace eonevapi.core.Models
{
    public class Geometry
    {
        public DateTime date { get; set; }
        public string type { get; set; }
        public ICollection<object> coordinates { get; set; }
    }
}