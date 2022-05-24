using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace AbpCommunityTalks.MongoDB;

[DependsOn(
    typeof(AbpCommunityTalksTestBaseModule),
    typeof(AbpCommunityTalksMongoDbModule)
    )]
public class AbpCommunityTalksMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = AbpCommunityTalksMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
