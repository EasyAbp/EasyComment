using System;
using EasyAbp.EasyComment.Permissions;
using EasyAbp.EasyComment.Comments.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EasyComment.Comments
{
    public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCommentDto, CreateUpdateCommentDto>,
        ICommentAppService
    {
        protected override string GetPolicyName { get; set; } = EasyCommentPermissions.Comment.Default;
        protected override string GetListPolicyName { get; set; } = EasyCommentPermissions.Comment.Default;
        protected override string CreatePolicyName { get; set; } = EasyCommentPermissions.Comment.Create;
        protected override string UpdatePolicyName { get; set; } = EasyCommentPermissions.Comment.Update;
        protected override string DeletePolicyName { get; set; } = EasyCommentPermissions.Comment.Delete;
        private readonly ICommentRepository _repository;
        
        public CommentAppService(ICommentRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}