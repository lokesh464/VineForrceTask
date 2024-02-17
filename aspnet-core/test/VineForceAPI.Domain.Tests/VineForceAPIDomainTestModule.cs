using Volo.Abp.Modularity;

namespace VineForceAPI;

[DependsOn(
    typeof(VineForceAPIDomainModule),
    typeof(VineForceAPITestBaseModule)
)]
public class VineForceAPIDomainTestModule : AbpModule
{

}
