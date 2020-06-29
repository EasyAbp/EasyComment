using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EasyComment.Comments
{
    public class Comment : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string ItemType { get; }
        public string ItemKey { get; }
        public string Content { get; }
        public Guid? ReplyTo { get; }
    }
}