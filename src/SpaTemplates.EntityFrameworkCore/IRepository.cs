using System.Collections.Generic;
using System.Threading.Tasks;
using SpaTemplates.Domain;

namespace SpaTemplates.EntityFrameworkCore
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        void Insert(TEntity appuser);
    }
}
