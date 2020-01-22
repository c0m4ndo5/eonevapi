using System;
using eonevapi.core.QueryOptions;

namespace eonevapi.api.Validators
{
    public class EventQueryOptionsValidator
    {
        public EventQueryOptions validate(DateTime? from, DateTime? to, string status, int category, string orderby)
        {
            //Simply convert from incoming URL parameters to the query options expected by the data service
            //Ensure the options are valid for the service
            if (from >= to) throw new Exception("Invalid date selection");

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
                if (orderby.EndsWith("desc")) direction = OrderingDirection.DESC;
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