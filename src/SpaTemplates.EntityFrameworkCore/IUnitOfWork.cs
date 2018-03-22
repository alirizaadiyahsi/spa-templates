using System;
using System.Threading.Tasks;

namespace SpaTemplates.EntityFrameworkCore
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}