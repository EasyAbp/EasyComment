using System;

using System.ComponentModel.DataAnnotations;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment.ViewModels
{
    public class CreateEditCommentViewModel
    {
        [Display(Name = "CommentItemType")]
        public string ItemType { get; set; }

        [Display(Name = "CommentItemKey")]
        public string ItemKey { get; set; }

        [Display(Name = "CommentContent")]
        public string Content { get; set; }

        [Display(Name = "CommentReplyTo")]
        public Guid? ReplyTo { get; set; }
    }
}