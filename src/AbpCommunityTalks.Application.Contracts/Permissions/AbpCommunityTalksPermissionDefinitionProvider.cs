using AbpCommunityTalks.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpCommunityTalks.Permissions;

public class AbpCommunityTalksPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpCommunityTalksPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpCommunityTalksPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpCommunityTalksResource>(name);
    }
}
