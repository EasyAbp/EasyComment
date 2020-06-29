using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.EasyComment.Comments
{
    public class Comment : FullAuditedEntity<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string Topic { get; set; }
        public string Content { get; }
        public Guid? ReplyTo { get; }
    }
}