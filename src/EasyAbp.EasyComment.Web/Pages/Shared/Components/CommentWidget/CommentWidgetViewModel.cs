using EasyAbp.EasyComment.Comments.Dtos;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    public class CommentWidgetViewModel
    {
        public CommentDto Comment { get; }

        public CommentWidgetViewModel(CommentDto comment)
        {
            Comment = comment;
        }
    }
}