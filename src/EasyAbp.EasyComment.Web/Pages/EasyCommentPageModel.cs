using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.EasyComment.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class EasyCommentPageModel : AbpPageModel
    {
        protected EasyCommentPageModel()
        {
            LocalizationResourceType = typeof(EasyCommentResource);
            ObjectMapperContext = typeof(EasyCommentWebModule);
        }
    }
}