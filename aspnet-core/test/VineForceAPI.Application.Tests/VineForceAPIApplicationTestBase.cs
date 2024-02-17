using Volo.Abp.Modularity;

namespace VineForceAPI;

public abstract class VineForceAPIApplicationTestBase<TStartupModule> : VineForceAPITestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
