using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.EasyComment.Comments;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    [ConnectionStringName(EasyCommentDbProperties.ConnectionStringName)]
    public interface IEasyCommentDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Comment> Comments { get; set; }
    }
}
