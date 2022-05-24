using Volo.Abp.Modularity;

namespace AbpCommunityTalks;

[DependsOn(
    typeof(AbpCommunityTalksApplicationModule),
    typeof(AbpCommunityTalksDomainTestModule)
    )]
public class AbpCommunityTalksApplicationTestModule : AbpModule
{

}
