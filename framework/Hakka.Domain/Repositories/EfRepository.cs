using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hakka.Domain.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity: class
    {
        private DbContext db;

        public EfRepository(DbContext db)
        {
            this.db = db;
        }

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await db.Set<TEntity>().AddAsync(entity, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            db.Attach(entity);
            var updatedEntity = db.Set<TEntity>().Update(entity).Entity;
            await db.SaveChangesAsync(cancellationToken);
            return updatedEntity;
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await db.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        {
            return await db.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            var data = await db.Set<TEntity>().ToListAsync(cancellationToken);
            return data.Count();
        }
    }
}
