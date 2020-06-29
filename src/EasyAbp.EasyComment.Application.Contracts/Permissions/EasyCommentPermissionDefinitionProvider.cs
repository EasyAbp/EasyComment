using EasyAbp.EasyComment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.EasyComment.Permissions
{
    public class EasyCommentPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(EasyCommentPermissions.GroupName, L("Permission:EasyComment"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EasyCommentResource>(name);
        }
    }
}