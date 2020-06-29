using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.EasyComment.MongoDB
{
    [ConnectionStringName(EasyCommentDbProperties.ConnectionStringName)]
    public interface IEasyCommentMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
