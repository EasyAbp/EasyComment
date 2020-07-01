using System;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    public class CommentViewerWidgetParameter
    {
        public Guid Id { get; set; }
        
        public string Content { get; set; }
        
        public bool FromServer { get; set; } 
    }
}