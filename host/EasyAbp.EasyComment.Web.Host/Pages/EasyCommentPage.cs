using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.EasyComment.Pages
{
    public abstract class EasyCommentPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<EasyCommentResource> L { get; set; }
    }
}
