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

        public class Comment
        {
            public const string Default = GroupName + ".Comment";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Management = Default + ".Update";
        }

    }
}
