using System;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    public class CommentEditorWidgetParameter
    {
        public Guid? Id { get; set; }
        
        public string Label { get; set; }
        
        public string Content { get; set; }

        public bool EditModel { get; set; }
    }
}