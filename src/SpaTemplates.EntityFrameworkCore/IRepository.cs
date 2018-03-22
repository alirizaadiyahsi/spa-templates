using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaTemplates.EntityFrameworkCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
    }
}
