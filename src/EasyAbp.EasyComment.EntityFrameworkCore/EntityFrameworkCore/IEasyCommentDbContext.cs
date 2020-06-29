using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    [ConnectionStringName(EasyCommentDbProperties.ConnectionStringName)]
    public interface IEasyCommentDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}