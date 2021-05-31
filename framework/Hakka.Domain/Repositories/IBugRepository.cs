using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hakka.Domain.Repositories
{
    /// <summary>
    /// Just to mark a class as repository
    /// </summary>
    public interface IRepository
    {
    }

    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(CancellationToken cancellationToken = default);
    }
}
