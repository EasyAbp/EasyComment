using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentDomainSharedModule)
        )]
    public class EasyCommentDomainModule : AbpModule
    {

    }
}
