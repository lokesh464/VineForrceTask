using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VineForceAPI.Repositories.IBaseRepo;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VineForceAPI.Repositories.Base
{
    public abstract class EfcoreBaseRepo<TDbContext, TEntity, TKey> : EfCoreRepository<TDbContext, TEntity, TKey>, IBaseRepo<TEntity, TKey>
         where TDbContext : IEfCoreDbContext
        where TEntity : class, IEntity<TKey>
    {
        protected EfcoreBaseRepo(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate, int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> queryable = await GetQueryable(includeDetails, propertySelectors);

            //Apply the predicate, if present.
            if (predicate != default(Expression<Func<TEntity, bool>>))
                queryable = queryable.Where(predicate);

            //Apply sorting.
            queryable = ApplySorting(queryable, sorting);

            //Apply pagination.
            return await AsyncExecuter.ToListAsync(queryable.PageBy(skipCount, maxResultCount));
        }

        private async Task<IQueryable<TEntity>> GetQueryable(bool includeDetails, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> queryable;

            if (includeDetails)
            {
                if (propertySelectors.Count() == 0)
                    queryable = await WithDetailsAsync();
                else
                    queryable = await WithDetailsAsync(propertySelectors);
            }
            else
            {
                queryable = await GetQueryableAsync();
            }

            return queryable;
        }

        public virtual async Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = await GetQueryableAsync();

            if (predicate != default(Expression<Func<TEntity, bool>>))
                return await AsyncExecuter.CountAsync(queryable, predicate, cancellationToken);
            else
                return await AsyncExecuter.CountAsync(queryable, cancellationToken);
        }

        public abstract IOrderedQueryable<TEntity> ApplySorting(IQueryable<TEntity> currentQueryable, string sorting);
    }
}
