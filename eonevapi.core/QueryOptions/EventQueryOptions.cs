using System;
using System.Collections.Generic;

namespace eonevapi.core.QueryOptions
{
    public enum EventOrdering
    {
        OrderByStatus,
        OrderByDate,
        OrderByCategory
    }
    public class EventQueryOptions
    {
        public DateTime SearchStart { get; set; }
        public DateTime SearchEnd { get; set; }
        public string FilterStatus { get; set; }
        public string FilterCategory { get; set; }
        public List<EventOrdering> SortingOptions { get; set; }
    }
}