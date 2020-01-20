using System;
using System.Collections.Generic;

namespace eonevapi.core.QueryOptions
{

    public class EventQueryOptions
    {
        public DateTime? SearchStart { get; set; }
        public DateTime? SearchEnd { get; set; }
        public string FilterStatus { get; set; }
        public int FilterCategory { get; set; }
        public OrderingOptions SortingOptions { get; set; }
    }
}