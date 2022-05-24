using AbpCommunityTalks.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpCommunityTalks.Blazor;

public abstract class AbpCommunityTalksComponentBase : AbpComponentBase
{
    protected AbpCommunityTalksComponentBase()
    {
        LocalizationResource = typeof(AbpCommunityTalksResource);
    }
}
