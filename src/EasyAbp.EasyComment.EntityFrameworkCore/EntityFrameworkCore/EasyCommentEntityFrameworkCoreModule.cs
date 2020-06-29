using EasyAbp.EasyComment.Comments;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    [DependsOn(
        typeof(EasyCommentDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class EasyCommentEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EasyCommentDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Comment, CommentRepository>();
            });
        }
    }
}
