using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace VineForceAPI;

[Dependency(ReplaceServices = true)]
public class VineForceAPIBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "VineForceAPI";
}
