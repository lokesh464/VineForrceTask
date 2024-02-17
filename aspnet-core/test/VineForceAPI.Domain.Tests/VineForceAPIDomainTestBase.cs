using Volo.Abp.Modularity;

namespace VineForceAPI;

/* Inherit from this class for your domain layer tests. */
public abstract class VineForceAPIDomainTestBase<TStartupModule> : VineForceAPITestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
