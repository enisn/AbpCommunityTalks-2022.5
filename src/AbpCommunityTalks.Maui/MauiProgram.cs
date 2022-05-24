using Microsoft.AspNetCore.Components.WebView.Maui;
using AbpCommunityTalks.Maui.Data;
using Volo.Abp.Autofac;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Volo.Abp;

namespace AbpCommunityTalks.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.ConfigureContainer(new AbpAutofacServiceProviderFactory(new Autofac.ContainerBuilder()));

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		ConfigureConfiguration(builder);

		builder.Services.AddApplication<AbpCommunityTalksMauiModule>(options =>
        {
			options.Services.ReplaceConfiguration(builder.Configuration);
        });

		var app = builder.Build();

        app.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>()
			.Initialize(app.Services);

        return app;
	}

    private static void ConfigureConfiguration(MauiAppBuilder builder)
    {
        var assembly = typeof(App).GetTypeInfo().Assembly;
        builder.Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);
    }
}
