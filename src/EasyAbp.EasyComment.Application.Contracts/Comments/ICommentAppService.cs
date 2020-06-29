using System;
using EasyAbp.EasyComment.Comments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EasyComment.Comments
{
    public interface ICommentAppService :
        ICrudAppService< 
            CommentDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCommentDto,
            CreateUpdateCommentDto>
    {

    }
}