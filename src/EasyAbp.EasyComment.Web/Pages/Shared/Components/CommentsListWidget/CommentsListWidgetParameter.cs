namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    public class CommentsListWidgetParameter
    {
        public string ItemType { get; set; }
        public string ItemKey { get;  set;}
        public string Sorting { get;  set;}
        public long LoadedCount { get;  set;}
        public int SkipCount { get;  set;}
        public int MaxResultCount { get;  set;}
    }
}