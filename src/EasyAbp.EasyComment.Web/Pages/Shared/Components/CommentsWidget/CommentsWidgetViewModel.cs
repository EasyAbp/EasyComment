using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsWidget
{
    public class CommentsWidgetViewModel
    {
        [HiddenInput]
        public string ItemType { get; set; }
        
        [HiddenInput]
        public string ItemKey { get; set; }
        
        public PagedResultDto<CommentDto> Comments { get; set; }
        public int TotalCount { get; set; }
        public int LoadCount { get; set; }
    }
}