using System;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using System.IdentityModel.Tokens.Jwt;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.Authentication;
using DependencyAttribute = Volo.Abp.DependencyInjection.DependencyAttribute;

namespace AbpCommunityTalks.Maui;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IRemoteServiceHttpClientAuthenticator))]
public class AccessTokenRemoteServiceHttpClientAuthenticator : IRemoteServiceHttpClientAuthenticator, ITransientDependency
{
    protected OidcClient OidcClient { get; }

    protected ISecureStorage Storage { get; }

    public AccessTokenRemoteServiceHttpClientAuthenticator(OidcClient oidcClient, ISecureStorage storage)
    {
        OidcClient = oidcClient;
        Storage = storage;
    }

    public async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
    {
        var currentAccessToken = await Storage.GetAsync(OidcConsts.AccessTokenKeyName);

        if (!currentAccessToken.IsNullOrEmpty())
        {
            // TODO: Find better way to find if token is expired instead of parsing it.
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(currentAccessToken) as JwtSecurityToken;
            if (jwtToken.ValidTo <= DateTime.UtcNow)
            {
                var refreshToken = await Storage.GetAsync(OidcConsts.RefreshTokenKeyName);
                if (!refreshToken.IsNullOrEmpty())
                {
                    var refreshResult = await OidcClient.RefreshTokenAsync(refreshToken);

                    await Storage.SetAsync(OidcConsts.AccessTokenKeyName, refreshResult.AccessToken);
                    await Storage.SetAsync(OidcConsts.RefreshTokenKeyName, refreshResult.RefreshToken);

                    context.Request.SetBearerToken(refreshResult.AccessToken);
                }
                else
                {
                    var loginResult = await OidcClient.LoginAsync(new LoginRequest());

                    await Storage.SetAsync(OidcConsts.AccessTokenKeyName, loginResult.AccessToken);
                    await Storage.SetAsync(OidcConsts.RefreshTokenKeyName, loginResult.RefreshToken);

                    context.Request.SetBearerToken(loginResult.AccessToken);
                }
            }

            context.Request.SetBearerToken(currentAccessToken);
        }
    }
}