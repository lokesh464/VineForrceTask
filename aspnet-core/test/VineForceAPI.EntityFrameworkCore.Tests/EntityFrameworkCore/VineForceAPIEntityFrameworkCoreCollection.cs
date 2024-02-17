using Xunit;

namespace VineForceAPI.EntityFrameworkCore;

[CollectionDefinition(VineForceAPITestConsts.CollectionDefinitionName)]
public class VineForceAPIEntityFrameworkCoreCollection : ICollectionFixture<VineForceAPIEntityFrameworkCoreFixture>
{

}
