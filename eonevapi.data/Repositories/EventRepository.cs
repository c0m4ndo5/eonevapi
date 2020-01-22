using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;

namespace eonevapi.data.Repositories
{
    //Responsible for initiating the call to get events and return the appropriate models
    //It is responsible for also getting and sending the appropriate filters specific to the api call
    public class EventRepository : IEventRepository
    {
        IEONETApiContext apiContext;
        public EventRepository(IEONETApiContext apiContext)
        {
            this.apiContext = apiContext;
        }
        public async Task<IEnumerable<Event>> GetAll()
        {
            JsonDocument result = await apiContext.CallAPI("events");

            return (IEnumerable<Event>)JsonSerializer.Deserialize(result.RootElement.GetProperty("events").ToString(),
            typeof(IEnumerable<Event>));
        }

        public async Task<Event> GetById(string id)
        {
            JsonDocument result = await apiContext.CallAPI("events/" + id);

            return (Event)JsonSerializer.Deserialize(result.RootElement.ToString(),
            typeof(Event));
        }

        public async Task<IEnumerable<Event>> GetFiltered(string status, int days = -1, int category = -1)
        {
            string url = "";
            if (category >= 0)
                url += "categories/" + category;
            else
                url += "events";
            if (days >= 0 || category >= 0 || status == "closed")
            {
                url += "?";
                if (days >= 0)
                    url += "days=" + days + "&";
                if (category >= 0)
                    url += "category=" + category + "&";
                if (status == "closed")
                    url += "status=" + status;
            }
            if (url.EndsWith("&")) url = url.Substring(0, url.Length - 1);
            JsonDocument result = await apiContext.CallAPI(url);
            return (IEnumerable<Event>)JsonSerializer.Deserialize(result.RootElement.GetProperty("events").ToString(),
            typeof(IEnumerable<Event>));
        }
    }
}