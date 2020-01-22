using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eonevapi.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        ILogger<CategoryController> logger;
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Gets a list of all available categories
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            try
            {
                return Ok(await categoryService.GetAllCategories());
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving all categories");
                return StatusCode(500, "Error retrieving available categories");
            }
        }
    }
}