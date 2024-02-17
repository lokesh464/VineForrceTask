using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VineForceAPI.Data;
using Volo.Abp.DependencyInjection;

namespace VineForceAPI.EntityFrameworkCore;

public class EntityFrameworkCoreVineForceAPIDbSchemaMigrator
    : IVineForceAPIDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreVineForceAPIDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the VineForceAPIDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<VineForceAPIDbContext>()
            .Database
            .MigrateAsync();
    }
}
