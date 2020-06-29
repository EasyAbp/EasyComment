using Volo.Abp.Reflection;

namespace EasyAbp.EasyComment.Permissions
{
    public class EasyCommentPermissions
    {
        public const string GroupName = "EasyComment";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(EasyCommentPermissions));
        }
    }
}