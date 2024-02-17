using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VineForceAPI.Entities;
using VineForceAPI.EntityFrameworkCore;
using VineForceAPI.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VineForceAPI.Repositories
{
    public class StateRepo : EfcoreBaseRepo<VineForceAPIDbContext, State, Guid>, IStateRepo
    {
        public StateRepo(IDbContextProvider<VineForceAPIDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task<List<State>> GetPagedListAsync(Expression<Func<State, bool>> predicate, int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default, params Expression<Func<State, object>>[] propertySelectors)
        {
            return base.GetPagedListAsync(predicate, skipCount, maxResultCount, sorting, includeDetails, cancellationToken, propertySelectors);
        }

        public override IOrderedQueryable<State> ApplySorting(IQueryable<State> currentQueryable, string sorting)
        {
            IOrderedQueryable<State> sorted = currentQueryable.OrderBy(s => 0);

            if (string.IsNullOrWhiteSpace(sorting))
                return sorted;

            string[] sort = sorting.Split(",");
            foreach (string s in sort)
            {
                switch (s)
                {
                    case "Name ASC":
                        sorted = sorted.ThenBy(x => x.Name);
                        break;

                    case "Name Desc":
                        sorted = sorted.ThenByDescending(x => x.Name);
                        break;
                };
            }

            return sorted;
        }
    }
}
