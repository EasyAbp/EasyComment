using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.EasyComment.MongoDB
{
    public static class EasyCommentMongoDbContextExtensions
    {
        public static void ConfigureEasyComment(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new EasyCommentMongoModelBuilderConfigurationOptions(
                EasyCommentDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}