using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;

namespace eonevapi.core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}