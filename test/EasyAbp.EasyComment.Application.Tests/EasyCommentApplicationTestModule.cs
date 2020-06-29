using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment
{
    [DependsOn(
        typeof(EasyCommentApplicationModule),
        typeof(EasyCommentDomainTestModule)
        )]
    public class EasyCommentApplicationTestModule : AbpModule
    {

    }
}
