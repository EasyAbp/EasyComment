using Localization.Resources.AbpUi;
using EasyAbp.EasyComment.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class EasyCommentHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(EasyCommentHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EasyCommentResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
