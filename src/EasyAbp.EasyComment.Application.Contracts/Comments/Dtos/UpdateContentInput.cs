﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.EasyComment.Comments.Dtos
{
    public class UpdateContentInput
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentConsts.MaxContentLength)]
        public string Content { get; set; }
    }
}