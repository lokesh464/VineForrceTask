using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VineForceAPI.Data;

/* This is used if database provider does't define
 * IVineForceAPIDbSchemaMigrator implementation.
 */
public class NullVineForceAPIDbSchemaMigrator : IVineForceAPIDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
