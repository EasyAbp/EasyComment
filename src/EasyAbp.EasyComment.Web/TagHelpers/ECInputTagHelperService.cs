using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.EasyComment.Web.TagHelpers
{
    [ExposeServices(typeof(AbpInputTagHelperService))]
    public class ECInputTagHelperService : AbpInputTagHelperService
    {
        public ECInputTagHelperService(IHtmlGenerator generator, HtmlEncoder encoder, IAbpTagHelperLocalizer tagHelperLocalizer) : base(generator, encoder, tagHelperLocalizer)
        {
        }

        protected override async Task<string> GetLabelAsHtmlAsync(TagHelperContext context, TagHelperOutput output, TagHelperOutput inputTag, bool isCheckbox)
        {
            if (inputTag.Attributes.ContainsName("no-label")) return "";

            return await base.GetLabelAsHtmlAsync(context, output, inputTag, isCheckbox);
        }
    }
}