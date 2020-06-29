using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EasyComment.Comments
{
    public class Comment : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }
        public virtual string ItemType { get; protected set; }
        public virtual string ItemKey { get; protected set; }
        public virtual string Content { get; protected set; }
        public virtual Guid? ReplyTo { get; protected set; }

        protected Comment()
        {
        }

        public Comment(Guid id, [NotNull] string itemType, [NotNull] string itemKey, [NotNull] string content, Guid? replyTo, Guid? tenantId = null) : base(id)
        {
            ItemType = Check.NotNullOrWhiteSpace(itemType, nameof(itemType));
            ItemKey = Check.NotNullOrWhiteSpace(itemType, nameof(itemType));;
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));;
            ReplyTo = replyTo;
            TenantId = tenantId;
        }

        public virtual Comment SetContent([NotNull] string content)
        {
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));;
            return this;
        }
    }
}