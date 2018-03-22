using System;
using System.Threading.Tasks;

namespace SpaTemplates.EntityFrameworkCore
{
    //todo: redesign unit of work
    public class UnitOfWork : IUnitOfWork, IRepositoryFactory
    {
        private bool _disposed;
        public SpaTemplatesContext DbContext { get; }

        public UnitOfWork(SpaTemplatesContext context)
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