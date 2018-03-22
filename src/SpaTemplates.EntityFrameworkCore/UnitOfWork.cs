using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaTemplates.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork, IRepositoryFactory
    {
        private bool _disposed;
        public DbContext DbContext { get; }

        public UnitOfWork(DbContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(DbContext);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}