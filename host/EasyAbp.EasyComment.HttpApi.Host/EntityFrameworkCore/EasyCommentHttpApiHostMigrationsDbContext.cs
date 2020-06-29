using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    public class EasyCommentHttpApiHostMigrationsDbContext : AbpDbContext<EasyCommentHttpApiHostMigrationsDbContext>
    {
        public EasyCommentHttpApiHostMigrationsDbContext(DbContextOptions<EasyCommentHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEasyComment();
        }
    }
}
