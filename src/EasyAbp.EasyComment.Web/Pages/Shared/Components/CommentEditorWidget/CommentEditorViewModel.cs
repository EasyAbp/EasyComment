using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    public class CommentEditorViewModel
    {
        public bool ShowLabel { get; set; }
        
        [Required(ErrorMessage = "NeedCommentContent")]
        [TextArea]
        [Display(Name = "CommentContent")]
        public string Content { get; set; }
    }
}