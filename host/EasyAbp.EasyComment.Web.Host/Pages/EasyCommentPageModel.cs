using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.EasyComment.Pages
{
    public abstract class EasyCommentPageModel : AbpPageModel
    {
        protected EasyCommentPageModel()
        {
            LocalizationResourceType = typeof(EasyCommentResource);
        }
    }
}