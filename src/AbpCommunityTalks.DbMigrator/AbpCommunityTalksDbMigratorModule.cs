using AbpCommunityTalks.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpCommunityTalks.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCommunityTalksMongoDbModule),
    typeof(AbpCommunityTalksApplicationContractsModule)
    )]
public class AbpCommunityTalksDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
