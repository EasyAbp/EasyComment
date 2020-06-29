using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.EasyComment.MongoDB
{
    [ConnectionStringName(EasyCommentDbProperties.ConnectionStringName)]
    public class EasyCommentMongoDbContext : AbpMongoDbContext, IEasyCommentMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureEasyComment();
        }
    }
}