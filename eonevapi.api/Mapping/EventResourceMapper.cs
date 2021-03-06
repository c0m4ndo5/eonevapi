using eonevapi.api.Resources;
using System.Linq;
using eonevapi.core.Models;
using System.Collections.Generic;
using System;

namespace eonevapi.api.Mapping
{
    public class EventResourceMapper
    {
        public EventResource mapToResource(Event e)
        {
            //Perform a simple mapping from the internal model returned by EONET to a 
            //more friendly/standard format for the front-end
            DateTime? closed = e.closed;
            if (e.closed == new DateTime())
            {
                closed = null;
            }
            EventResource result = new EventResource()
            {
                id = e.id,
                title = e.title,
                closed = closed,
                description = e.description,
                link = e.link,
            };
            //The most recent geometry helps identify a "modified" date for the event and make a map link
            if (e.categories.Count > 0)
                result.categoryId = e.categories.ElementAt(0).id;
            if (e.geometries.Count > 0)
            {
                var lastGeometry = e.geometries.ElementAt(0);
                result.lastGeometryDate = lastGeometry.date;
                try
                {
                    result.lastGeometryX = double.Parse(lastGeometry.coordinates.ElementAt(0).ToString());
                    result.lastGeometryY = double.Parse(lastGeometry.coordinates.ElementAt(1).ToString());
                }
                catch (Exception) { }
            }

            return result;
        }

        public IEnumerable<EventResource> mapToResourceList(IEnumerable<Event> listE)
        {
            return listE.ToList().ConvertAll(e => mapToResource(e));
        }
    }
}