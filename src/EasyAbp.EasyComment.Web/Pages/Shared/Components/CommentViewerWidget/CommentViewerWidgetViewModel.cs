using System;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    public class CommentViewerWidgetViewModel 
    {
        public Guid Id { get; }
        
        public string Content { get; }

        public CommentViewerWidgetViewModel(Guid id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}