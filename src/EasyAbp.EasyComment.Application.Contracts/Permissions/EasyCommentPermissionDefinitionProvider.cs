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

            var commentPermission = myGroup.AddPermission(EasyCommentPermissions.Comment.Default, L("Permission:Comment"));
            commentPermission.AddChild(EasyCommentPermissions.Comment.Create, L("Permission:Create"));
            commentPermission.AddChild(EasyCommentPermissions.Comment.Update, L("Permission:Update"));
            commentPermission.AddChild(EasyCommentPermissions.Comment.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EasyCommentResource>(name);
        }
    }
}
