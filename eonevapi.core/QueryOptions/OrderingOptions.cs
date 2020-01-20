namespace eonevapi.core.QueryOptions
{
    public enum EventOrderingOptions
    {
        OrderByStatus,
        OrderByDate,
        OrderByCategory
    }
    public enum OrderingDirection
    {
        ASC,
        DESC
    }
    public class OrderingOptions
    {
        public EventOrderingOptions OrderingOption { get; set; }
        public OrderingDirection Direction { get; set; }
    }
}