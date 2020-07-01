using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    [Serializable]
    public class CommentDto : FullAuditedEntityDto<Guid>
    {
        public string ItemType { get; set; }

        public string ItemKey { get; set; }

        public string Content { get; set; }

        public Guid? ReplyTo { get; set; }
        
        public string CreatorName { get; set; }
        public string ReplyToName { get; set; }
    }
}