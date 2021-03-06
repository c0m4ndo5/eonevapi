using System.Collections.Generic;
using System.Threading.Tasks;
using eonevapi.core.Models;
using eonevapi.core.Repositories;
using eonevapi.core.Services;

namespace eonevapi.services
{
    //Utilize the unit of work and it's repositories to get categories available
    public class CategoryService : ICategoryService
    {
        IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await unitOfWork.categoryRepository.GetAll();
        }
    }
}