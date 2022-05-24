using AbpCommunityTalks.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpCommunityTalks.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpCommunityTalksController : AbpControllerBase
{
    protected AbpCommunityTalksController()
    {
        LocalizationResource = typeof(AbpCommunityTalksResource);
    }
}
