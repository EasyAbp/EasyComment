using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.EasyComment.Comments
{
    [RemoteService(Name = "CommentService")]
    [Route("/api/easyComment/comment")]
    public class CommentController : EasyCommentController, ICommentAppService
    {
        private readonly ICommentAppService _service;

        public CommentController(ICommentAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CommentDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CommentDto>> GetListAsync(GetListInput input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CommentDto> CreateAsync(CreateUpdateCommentDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CommentDto> UpdateAsync(Guid id, CreateUpdateCommentDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpPost]
        [Route("comment")]
        public Task<CommentDto> AddCommentAsync(CreateUpdateCommentDto input)
        {
            return _service.AddCommentAsync(input);
        }

        [HttpPut]
        [Route("content")]
        public Task<CommentDto> UpdateContentAsync(UpdateContentInput input)
        {
            return _service.UpdateContentAsync(input);
        }

        [HttpDelete]
        [Route("{id}/comment")]
        public Task RemoveCommentAsync(Guid id)
        {
            return _service.RemoveCommentAsync(id);
        }

        [HttpGet]
        [Route("totalCount")]
        public Task<long> GetTotalCount(GetListInput input)
        {
            return _service.GetTotalCount(input);
        }
    }
}