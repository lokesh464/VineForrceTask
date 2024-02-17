using Volo.Abp.Settings;

namespace VineForceAPI.Settings;

public class VineForceAPISettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VineForceAPISettings.MySetting1));
    }
}
