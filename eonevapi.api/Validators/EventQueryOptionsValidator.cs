using System;
using eonevapi.core.QueryOptions;

namespace eonevapi.api.Validators
{
    public class EventQueryOptionsValidator
    {
        public EventQueryOptions validate(DateTime? from, DateTime? to, string status, int category, string orderby)
        {
            if (from >= to) return null;

            EventQueryOptions options = new EventQueryOptions()
            {
                SearchStart = from,
                SearchEnd = to,
                FilterStatus = status == "closed" ? "closed" : "open",
                FilterCategory = category > 0 ? category : -1
            };
            if (orderby != null)
            {
                EventOrderingOptions orderingOptions = EventOrderingOptions.OrderByDate;
                OrderingDirection direction = OrderingDirection.ASC;
                if (orderby.StartsWith("date")) orderingOptions = EventOrderingOptions.OrderByDate;
                if (orderby.StartsWith("category")) orderingOptions = EventOrderingOptions.OrderByCategory;
                if (orderby.StartsWith("status")) orderingOptions = EventOrderingOptions.OrderByStatus;
                if (orderby.EndsWith("Desc")) direction = OrderingDirection.DESC;
                options.SortingOptions = new OrderingOptions()
                {
                    OrderingOption = orderingOptions,
                    Direction = direction
                };
            }
            return options;
        }
    }
}