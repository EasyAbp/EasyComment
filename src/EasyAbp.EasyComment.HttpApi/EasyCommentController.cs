using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.EasyComment
{
    public abstract class EasyCommentController : AbpController
    {
        protected EasyCommentController()
        {
            LocalizationResource = typeof(EasyCommentResource);
        }
    }
}
