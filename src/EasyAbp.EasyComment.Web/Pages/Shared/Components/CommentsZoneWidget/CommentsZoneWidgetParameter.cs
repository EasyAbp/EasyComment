namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsZoneWidget
{
    public class CommentsZoneWidgetParameter
    {
        public string ItemType { get; }
        public string ItemKey { get; }
        public string Sorting { get; }
        public int MaxResultCount { get; }

        public CommentsZoneWidgetParameter(string itemType, string itemKey, string sorting, int maxResultCount)
        {
            ItemType = itemType;
            ItemKey = itemKey;
            Sorting = sorting;
            MaxResultCount = maxResultCount;
        }
    }
}