using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    public class CommentWidgetViewModel
    {
        [HiddenInput]
        public string ItemType { get; set; }
        
        [HiddenInput]
        public string ItemKey { get; set; }
        
        public PagedResultDto<CommentDto> Comments { get; set; }

    }
}