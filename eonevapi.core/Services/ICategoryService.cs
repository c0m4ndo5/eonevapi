using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Services
{
    //Define available service methods for categories
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}