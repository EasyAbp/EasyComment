using System.Collections.Generic;
using EasyAbp.EasyComment.Comments.Dtos;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    public class CommentsListWidgetViewModel
    {
        public IReadOnlyList<CommentDto> Comments { get; }

        public long LoadedCount { get; }
        public long TotalCount { get; }

        public bool HasMore => LoadedCount < TotalCount;

        public CommentsListWidgetViewModel(IReadOnlyList<CommentDto> comments, long loadedCount, long totalCount)
        {
            TotalCount = totalCount;
            LoadedCount = loadedCount;
            Comments = comments;
        }
    }
}