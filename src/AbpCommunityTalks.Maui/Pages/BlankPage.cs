using Volo.Abp.DependencyInjection;

namespace AbpCommunityTalks.Maui.Pages;
public class BlankPage : ContentPage, ITransientDependency
{
    public BlankPage()
    {
        Content = new Label
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Text = "Coming Soon..."
        };
    }
}
