using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class EasyCommentConsoleApiClientModule : AbpModule
    {
        
    }
}
