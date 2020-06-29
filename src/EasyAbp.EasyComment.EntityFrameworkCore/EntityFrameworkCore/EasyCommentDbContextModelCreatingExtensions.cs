using EasyAbp.EasyComment.Comments;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.EasyComment.EntityFrameworkCore
{
    public static class EasyCommentDbContextModelCreatingExtensions
    {
        public static void ConfigureEasyComment(
            this ModelBuilder builder,
            Action<EasyCommentModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new EasyCommentModelBuilderConfigurationOptions(
                EasyCommentDbProperties.DbTablePrefix,
                EasyCommentDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<Comment>(b =>
            {
                b.ToTable(options.TablePrefix + "Comments", options.Schema);
                b.ConfigureByConvention();

                b.Property(c => c.ItemType).IsRequired().HasMaxLength(CommentConsts.MaxItemTypeLength);
                b.Property(c => c.ItemKey).IsRequired().HasMaxLength(CommentConsts.MaxItemKeyLength);
                b.Property(c => c.Content).IsRequired().HasMaxLength(CommentConsts.MaxContentLength);

                b.HasIndex(c => new {c.ItemType, c.ItemKey});
            });
        }
    }
}
