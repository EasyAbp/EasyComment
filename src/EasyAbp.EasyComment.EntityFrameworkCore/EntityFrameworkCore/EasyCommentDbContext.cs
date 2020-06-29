using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    [ConnectionStringName(EasyCommentDbProperties.ConnectionStringName)]
    public class EasyCommentDbContext : AbpDbContext<EasyCommentDbContext>, IEasyCommentDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public EasyCommentDbContext(DbContextOptions<EasyCommentDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureEasyComment();
        }
    }
}