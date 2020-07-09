namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsWidget
{
    public class CommentsWidgetParameter
    {
        public string ItemType { get; set; }
        public string ItemKey { get; set; }
        public int Page { get; set; }
        public int CommentsCountPerPage { get; set; }
        public string Sorting { get; set; }
    }
}