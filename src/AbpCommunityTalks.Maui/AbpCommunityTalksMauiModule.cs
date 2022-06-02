using System;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Options;
using Volo.Abp.Modularity;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;

namespace AbpCommunityTalks.Maui;

public class AbpCommunityTalksMauiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<OidcClientOptions>(configuration.GetSection("Oidc:Options"));

        context.Services.AddTransient<OidcClient>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<OidcClientOptions>>().Value;
            options.Browser = sp.GetRequiredService<WebAuthenticatorBrowser>();
            return new OidcClient(options);
        });
    }
}