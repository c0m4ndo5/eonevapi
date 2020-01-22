using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.api.Mapping;
using eonevapi.api.Validators;
using eonevapi.core.Models;
using eonevapi.core.QueryOptions;
using eonevapi.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using eonevapi.api.Resources;

namespace eonevapi.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        ILogger<EventsController> logger;
        IEventService eventService;
        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            this.logger = logger;
            this.eventService = eventService;
        }

        /// <summary>
        /// Gets a list of all events matching filters and sorting provided, up to a limit of 50
        /// </summary>
        /// <param name="from">Search from date (example 2019-12-01)</param>
        /// <param name="to">Search to date (example 2019-12-31)</param>
        /// <param name="status">Search for open/closed events only (if empty, open is used by default)</param>
        /// <param name="category">Show events in one specific category (example 8, which is Wildfires)</param>
        /// <param name="orderby">Order by status/category/date (example: statusAsc)</param>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetEvents(DateTime? from, DateTime? to, string status, int category, string orderby)
        {
            //Validate incoming request options and return a query options object
            EventQueryOptionsValidator validator = new EventQueryOptionsValidator();
            EventQueryOptions options = validator.validate(from, to, status, category, orderby);

            if (options == null) return BadRequest("Invalid query options");
            else
            {
                try
                {
                    //Retrieve events according to filter
                    var queryResult = await eventService.GetFiltered(options);
                    //Use a mapper to return a friendly format for the front-end
                    //On a larger project with more models, use of a library such as AutoMapper might be more convenient
                    EventResourceMapper mapper = new EventResourceMapper();
                    var resourceReturn = mapper.mapToResourceList(queryResult);
                    return Ok(resourceReturn);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Error retrieving events");
                    return StatusCode(500, "Error retrieving events");
                }

            }
        }
        /// <summary>
        /// Gets details of a specific event
        /// </summary>
        /// <param name="id">ID of event (example EONET-1234)</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(string id)
        {
            try
            {
                var result = await eventService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving event details");
                return StatusCode(500, "Error retrieving event details");
            }
        }
    }
}