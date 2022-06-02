using System;
using IdentityModel.OidcClient;
using Volo.Abp.DependencyInjection;

namespace AbpCommunityTalks.Maui;

public partial class MainPage : ContentPage, ITransientDependency
{
    protected OidcClient OidcClient { get; }
    protected ISecureStorage Storage { get; }

    public MainPage(OidcClient oidcClient, ISecureStorage storage)
    {
        InitializeComponent();
        OidcClient = oidcClient;
        Storage = storage;
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
    }
}

