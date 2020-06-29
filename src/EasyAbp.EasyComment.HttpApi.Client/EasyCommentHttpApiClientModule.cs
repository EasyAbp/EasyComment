using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class EasyCommentHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyComment";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(EasyCommentApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
