using System;
using IdentityModel.OidcClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace AbpCommunityTalks.Maui;

public partial class MainPage : ContentPage, ITransientDependency
{
    protected OidcClient OidcClient { get; }
    protected ISecureStorage Storage { get; }
    protected IServiceProvider ServiceProvider { get; }

    public MainPage(OidcClient oidcClient, ISecureStorage storage, IServiceProvider serviceProvider/*, IStringLocalizer l*/)
    {
        InitializeComponent();
        OidcClient = oidcClient;
        Storage = storage;
        ServiceProvider = serviceProvider;

        //welcome.Text = l["Welcome"];
        //welcomeLong.Text = l["LongWelcomeMessage"];
    }

    async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await OidcClient.LoginAsync(new LoginRequest());
        if (loginResult.IsError)
        {
            await DisplayAlert("Error", loginResult.Error, "Close");
            return;
        }

        await Storage.SetAsync(OidcConsts.AccessTokenKeyName, loginResult.AccessToken);
        await Storage.SetAsync(OidcConsts.RefreshTokenKeyName, loginResult.RefreshToken);

        App.Current.MainPage = ServiceProvider.GetRequiredService<AppShell>();
    }
}