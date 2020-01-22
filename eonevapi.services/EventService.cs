using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using eonevapi.core.Models;
using eonevapi.core.QueryOptions;
using eonevapi.core.Repositories;
using eonevapi.core.Services;

namespace eonevapi.services
{
    //Utilize the UnitOfWork and it's repositories to retrieve events
    //This class is also responsible for doing internal business logic
    //Per requirements, this means filtering and ordering the data according to input
    public class EventService : IEventService
    {
        IUnitOfWork unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await unitOfWork.eventRepository.GetAll();
        }

        public async Task<Event> GetById(string id)
        {
            return await unitOfWork.eventRepository.GetById(id);
        }

        private IOrderedEnumerable<Event> OrderByAscDesc<TKey>(OrderingDirection direction, IEnumerable<Event> input, Func<Event, TKey> selector)
        {
            if (direction == OrderingDirection.ASC)
                return input.OrderBy(selector);
            else
                return input.OrderByDescending(selector);
        }
        public async Task<IEnumerable<Event>> GetFiltered(EventQueryOptions queryOptions)
        {
            int daysToQuery = -1;
            if (queryOptions.SearchStart != null)
            {
                var start = (DateTime)queryOptions.SearchStart;
                daysToQuery = (DateTime.Now - start).Days;
            }

            var queryResult = await unitOfWork.eventRepository.GetFiltered(queryOptions.FilterStatus, daysToQuery, queryOptions.FilterCategory);
            if (queryOptions.SearchEnd != null)
            {
                queryResult = queryResult.Where(e =>
                {
                    if (e.closed != DateTime.MinValue)
                    {
                        return e.closed < queryOptions.SearchEnd;
                    }
                    else
                    {
                        if (e.geometries.Count() > 0)
                            return e.geometries.ElementAt(0).date < queryOptions.SearchEnd;
                        else
                            return false;
                    }
                });
            }
            //Filter in the order of priority of the SortingOptions list order
            if (queryOptions.SortingOptions != null)
            {
                switch (queryOptions.SortingOptions.OrderingOption)
                {
                    case EventOrderingOptions.OrderByCategory:
                        queryResult = OrderByAscDesc(queryOptions.SortingOptions.Direction, queryResult,
                        e =>
                            {
                                if (e.categories.Count == 0) return 0;
                                else return e.categories.ElementAt(0).id;
                            });
                        break;
                    case EventOrderingOptions.OrderByStatus:
                        queryResult = OrderByAscDesc(queryOptions.SortingOptions.Direction, queryResult,
                        e =>
                            {
                                if (e.closed == new DateTime()) return DateTime.Now;
                                else return e.closed;
                            });
                        break;
                    case EventOrderingOptions.OrderByDate: //Use geometries dates for date sorting as overall event date property does not exist
                        queryResult = OrderByAscDesc(queryOptions.SortingOptions.Direction, queryResult,
                        e =>
                            {
                                if (e.geometries.Count > 0) return e.geometries.ElementAt(0).date;
                                else if (e.closed != new DateTime()) return e.closed;
                                else return DateTime.Now;
                            });
                        break;
                }

            }
            //Hard limit of 50 so as to not display too many items
            //A better approach for a future version would be to develop pagination
            return queryResult.Take(50);
        }
    }
}