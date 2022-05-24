using Volo.Abp.Modularity;

namespace AbpCommunityTalks.Maui;
public class AbpCommunityTalksMauiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMauiBlazorWebView();
#if DEBUG
        context.Services.AddBlazorWebViewDeveloperTools();
#endif
    }
}
