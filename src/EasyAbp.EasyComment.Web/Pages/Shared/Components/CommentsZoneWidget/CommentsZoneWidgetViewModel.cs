namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsZoneWidget
{
    public class CommentsZoneWidgetViewModel
    {
        public string ItemType { get; }

        public string ItemKey { get; }

        public string Sorting { get; }

        public int MaxResultCount { get; }
        
        public long TotalCount { get; }

        public CommentsZoneWidgetViewModel(string itemType, string itemKey, string sorting, int maxResultCount, long totalCount)
        {
            ItemType = itemType;
            ItemKey = itemKey;
            Sorting = sorting;
            MaxResultCount = maxResultCount;
            TotalCount = totalCount;
        }
    }
}