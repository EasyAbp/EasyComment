namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsWidget
{
    public class CommentsWidgetParameter
    {
        public string ItemType { get; set; }
        public string ItemKey { get; set; }
        public string Sorting { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}