using EasyAbp.EasyComment.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.EasyComment
{
    public abstract class EasyCommentAppService : ApplicationService
    {
        protected EasyCommentAppService()
        {
            LocalizationResource = typeof(EasyCommentResource);
            ObjectMapperContext = typeof(EasyCommentApplicationModule);
        }
    }
}
