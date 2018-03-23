using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaTemplates.Domain;

namespace SpaTemplates.EntityFrameworkCore
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly SpaTemplatesContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SpaTemplatesContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public void Insert(TEntity appuser)
        {
            DbSet.Add(appuser);
        }
    }
}