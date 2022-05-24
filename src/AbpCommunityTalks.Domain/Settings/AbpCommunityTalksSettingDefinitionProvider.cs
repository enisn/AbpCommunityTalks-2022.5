using Volo.Abp.Settings;

namespace AbpCommunityTalks.Settings;

public class AbpCommunityTalksSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpCommunityTalksSettings.MySetting1));
    }
}
