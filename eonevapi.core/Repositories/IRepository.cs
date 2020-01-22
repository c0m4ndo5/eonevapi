using System.Collections.Generic;
using System.Threading.Tasks;

namespace eonevapi.core.Repositories
{
    //Define a repository for the repository pattern. In this case there are no common methods to all repositories
    public interface IRepository<T> where T : class
    {

    }
}