using System.Threading.Tasks;
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
            GetListInput,
            CreateUpdateCommentDto,
            CreateUpdateCommentDto>
    {
        Task<CommentDto> AddCommentAsync(CreateUpdateCommentDto input);
        Task<CommentDto> UpdateContentAsync(UpdateContentInput input);
        Task RemoveCommentAsync(Guid id);
    }
}
