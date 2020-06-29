using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.EasyComment.MongoDB
{
    [DependsOn(
        typeof(EasyCommentTestBaseModule),
        typeof(EasyCommentMongoDbModule)
        )]
    public class EasyCommentMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}