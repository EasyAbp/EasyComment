using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    [Serializable]
    public class CreateUpdateCommentDto
    {
        [Required]
        [MaxLength(CommentConsts.MaxItemTypeLength)]
        public string ItemType { get; set; }

        [Required]
        [MaxLength(CommentConsts.MaxItemKeyLength)]
        public string ItemKey { get; set; }

        [Required]
        [MaxLength(CommentConsts.MaxContentLength)]
        public string Content { get; set; }

        public Guid? ReplyTo { get; set; }
    }
}