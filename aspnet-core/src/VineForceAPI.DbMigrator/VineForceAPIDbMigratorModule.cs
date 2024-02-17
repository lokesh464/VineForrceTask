using VineForceAPI.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VineForceAPI.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VineForceAPIEntityFrameworkCoreModule),
    typeof(VineForceAPIApplicationContractsModule)
    )]
public class VineForceAPIDbMigratorModule : AbpModule
{
}
