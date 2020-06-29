namespace EasyAbp.EasyComment
{
    public static class EasyCommentDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyComment";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyComment";
    }
}
