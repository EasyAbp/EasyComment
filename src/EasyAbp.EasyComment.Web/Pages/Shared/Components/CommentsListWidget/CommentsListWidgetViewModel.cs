using System.Collections.Generic;
using EasyAbp.EasyComment.Comments.Dtos;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    public class CommentsListWidgetViewModel
    {
        public IReadOnlyList<CommentDto> Comments { get; }
        
        public long TotalCount { get; }

        public bool HasMore { get; }

        public CommentsListWidgetViewModel(IReadOnlyList<CommentDto> comments, long totalCount, bool hasMore)
        {
            TotalCount = totalCount;
            HasMore = hasMore;
            Comments = comments;
        }
    }
}