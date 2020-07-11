namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    public class CommentsListWidgetParameter
    {
        public string ItemType { get; }
        public string ItemKey { get; }
        public string Sorting { get; }
        public long LoadedCount { get; }
        public int SkipCount { get; }
        public int MaxResultCount { get; }

        public CommentsListWidgetParameter(string itemType, string itemKey, string sorting, long loadedCount, int skipCount, int maxResultCount)
        {
            ItemType = itemType;
            ItemKey = itemKey;
            Sorting = sorting;
            LoadedCount = loadedCount;
            SkipCount = skipCount;
            MaxResultCount = maxResultCount;
        }
    }
}