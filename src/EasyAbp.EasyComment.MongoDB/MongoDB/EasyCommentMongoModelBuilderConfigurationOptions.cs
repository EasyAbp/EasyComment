using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.EasyComment.MongoDB
{
    public class EasyCommentMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public EasyCommentMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}