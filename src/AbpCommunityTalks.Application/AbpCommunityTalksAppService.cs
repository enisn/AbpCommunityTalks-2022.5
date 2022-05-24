using System;
using System.Collections.Generic;
using System.Text;
using AbpCommunityTalks.Localization;
using Volo.Abp.Application.Services;

namespace AbpCommunityTalks;

/* Inherit your application services from this class.
 */
public abstract class AbpCommunityTalksAppService : ApplicationService
{
    protected AbpCommunityTalksAppService()
    {
        LocalizationResource = typeof(AbpCommunityTalksResource);
    }
}
