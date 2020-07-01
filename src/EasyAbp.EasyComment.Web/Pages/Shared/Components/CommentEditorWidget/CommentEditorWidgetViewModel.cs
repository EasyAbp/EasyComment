using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    public class CommentEditorWidgetViewModel
    {
        public Guid? Id { get; set; }
        
        public string Label { get; set; }
        
        [Required(ErrorMessage = "NeedCommentContent")]
        [TextArea]
        [Display(Name = "CommentContent")]
        public string Content { get; set; }

        public bool EditModel { get; set; }
    }
}