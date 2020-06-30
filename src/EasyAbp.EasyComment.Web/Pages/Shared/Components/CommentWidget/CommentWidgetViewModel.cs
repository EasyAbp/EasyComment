using System.ComponentModel.DataAnnotations;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    public class CommentWidgetViewModel
    {
        [HiddenInput]
        public string ItemType { get; set; }
        
        [HiddenInput]
        public string ItemKey { get; set; }
        
        public PagedResultDto<CommentDto> Comments { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "NeedCommentContent")]
        [TextArea]
        [Display(Name = "CommentContent")]
        public string Content { get; set; }
    }
}