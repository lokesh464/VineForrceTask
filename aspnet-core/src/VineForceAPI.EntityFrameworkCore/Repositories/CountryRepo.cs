using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VineForceAPI.Entities;
using VineForceAPI.EntityFrameworkCore;
using VineForceAPI.Repositories.Base;
using Volo.Abp.EntityFrameworkCore;

namespace VineForceAPI.Repositories
{
    public class CountryRepo : EfcoreBaseRepo<VineForceAPIDbContext, Country, Guid>, ICountryRepo
    {
        public CountryRepo(IDbContextProvider<VineForceAPIDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task<List<Country>> GetPagedListAsync(Expression<Func<Country, bool>> predicate, int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default, params Expression<Func<Country, object>>[] propertySelectors)
        {
            return base.GetPagedListAsync(predicate, skipCount, maxResultCount, sorting, includeDetails, cancellationToken, propertySelectors);
        }

        public override IOrderedQueryable<Country> ApplySorting(IQueryable<Country> currentQueryable, string sorting)
        {
            IOrderedQueryable<Country> sorted = currentQueryable.OrderBy(s => 0);

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
