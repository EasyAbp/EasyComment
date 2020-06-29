using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    public class EasyCommentModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public EasyCommentModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}