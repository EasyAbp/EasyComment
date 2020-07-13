using System;
using EasyAbp.EasyComment.CommentUsers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EasyAbp.EasyComment.Web.Pages.Shared.TagHelpers
{
    [HtmlTargetElement("img", Attributes = "comment-creator")]
    public class UserAvatarTagHelper : TagHelper
    {
        public static string DefaultImageUrl = "/images/default_avatar.png";

        [HtmlAttributeName("comment-creator")]
        public CommentUserDto CommentCreator { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var imgSrc = CommentCreator.Avatar.IsNullOrEmpty() ? DefaultImageUrl : CommentCreator.Avatar;
            output.Attributes.SetAttribute("src", imgSrc);
        }
    }
}