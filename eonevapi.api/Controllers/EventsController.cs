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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResource>>> GetEvents(DateTime? from, DateTime? to, string status, int category, string orderby)
        {
            EventQueryOptionsValidator validator = new EventQueryOptionsValidator();
            EventQueryOptions options = validator.validate(from, to, status, category, orderby);

            if (options == null) return BadRequest("Invalid query options");
            else
            {
                var queryResult = await eventService.GetFiltered(options);
                EventResourceMapper mapper = new EventResourceMapper();
                var resourceReturn = mapper.mapToResourceList(queryResult);
                return Ok(resourceReturn);//Error handling
            }
        }
    }
}