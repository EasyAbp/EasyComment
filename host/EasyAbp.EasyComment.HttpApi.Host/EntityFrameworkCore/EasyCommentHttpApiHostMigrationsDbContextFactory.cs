using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    public class EasyCommentHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<EasyCommentHttpApiHostMigrationsDbContext>
    {
        public EasyCommentHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EasyCommentHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("EasyComment"));

            return new EasyCommentHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
