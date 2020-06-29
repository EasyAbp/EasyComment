using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.EasyComment.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits EasyAbp.EasyComment.Web.Pages.EasyCommentPage
     */
    public abstract class EasyCommentPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<EasyCommentResource> L { get; set; }
    }
}
