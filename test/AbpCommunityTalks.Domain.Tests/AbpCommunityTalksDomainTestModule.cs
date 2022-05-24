using AbpCommunityTalks.MongoDB;
using Volo.Abp.Modularity;

namespace AbpCommunityTalks;

[DependsOn(
    typeof(AbpCommunityTalksMongoDbTestModule)
    )]
public class AbpCommunityTalksDomainTestModule : AbpModule
{

}
