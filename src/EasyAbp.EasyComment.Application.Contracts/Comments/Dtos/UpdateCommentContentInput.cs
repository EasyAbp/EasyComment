using System;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    public class UpdateCommentContentInput
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentConsts.MaxContentLength)]
        public string Content { get; set; }
    }
}