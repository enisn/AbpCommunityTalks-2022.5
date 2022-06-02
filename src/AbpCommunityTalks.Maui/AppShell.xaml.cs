using Volo.Abp.DependencyInjection;

namespace AbpCommunityTalks.Maui;

public partial class AppShell : Shell, ITransientDependency
{
    public AppShell()
    {
        InitializeComponent();
    }
}
