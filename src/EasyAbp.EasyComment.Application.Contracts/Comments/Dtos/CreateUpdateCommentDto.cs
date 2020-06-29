using System;
using System.ComponentModel;
namespace EasyAbp.EasyComment.Comments.Dtos
{
    [Serializable]
    public class CreateUpdateCommentDto
    {
        public string ItemType { get; set; }

        public string ItemKey { get; set; }

        public string Content { get; set; }

        public Guid? ReplyTo { get; set; }
    }
}