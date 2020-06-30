using System;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    public class CommentViewerViewModel 
    {
        public Guid Id { get; set; }
        public string ItemType { get; set; }
        public string ItemKey { get; set; }
        public string Content { get; set; } 
    }
}