using VineForceAPI.Samples;
using Xunit;

namespace VineForceAPI.EntityFrameworkCore.Applications;

[Collection(VineForceAPITestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<VineForceAPIEntityFrameworkCoreTestModule>
{

}
