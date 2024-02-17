using VineForceAPI.Samples;
using Xunit;

namespace VineForceAPI.EntityFrameworkCore.Domains;

[Collection(VineForceAPITestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<VineForceAPIEntityFrameworkCoreTestModule>
{

}
