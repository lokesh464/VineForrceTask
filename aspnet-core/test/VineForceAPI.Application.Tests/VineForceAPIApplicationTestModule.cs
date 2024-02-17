using Volo.Abp.Modularity;

namespace VineForceAPI;

[DependsOn(
    typeof(VineForceAPIApplicationModule),
    typeof(VineForceAPIDomainTestModule)
)]
public class VineForceAPIApplicationTestModule : AbpModule
{

}
