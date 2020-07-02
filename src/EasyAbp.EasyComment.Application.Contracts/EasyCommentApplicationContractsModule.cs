using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class EasyCommentApplicationContractsModule : AbpModule
    {

    }
}
