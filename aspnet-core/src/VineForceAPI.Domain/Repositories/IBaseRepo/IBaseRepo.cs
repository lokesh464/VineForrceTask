using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace VineForceAPI.Repositories.IBaseRepo
{
    public interface IBaseRepo<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
