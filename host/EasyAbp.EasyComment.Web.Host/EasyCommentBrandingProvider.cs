using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.EasyComment
{
    [Dependency(ReplaceServices = true)]
    public class EasyCommentBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "EasyComment";
    }
}
