using EasyAbp.EasyComment.Comments.Dtos;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    public class CommentWidgetParameter
    {
        public CommentDto Comment { get; }

        public CommentWidgetParameter(CommentDto comment)
        {
            Comment = comment;
        }
    }
}