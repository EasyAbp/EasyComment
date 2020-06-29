using System;
using System.Linq;
using EasyAbp.EasyComment.Permissions;
using EasyAbp.EasyComment.Comments.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.EasyComment.Comments
{
    public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, GetListInput, CreateUpdateCommentDto, CreateUpdateCommentDto>,
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

        protected override IQueryable<Comment> CreateFilteredQuery(GetListInput input)
        {
            return _repository
                    .WhereIf(!input.ItemType.IsNullOrEmpty(), c => c.ItemType == input.ItemType)
                    .WhereIf(!input.ItemKey.IsNullOrEmpty(), c => c.ItemKey == input.ItemKey)
                ;
        }

        protected override IQueryable<Comment> ApplySorting(IQueryable<Comment> query, GetListInput input)
        {
            if (input.Sorting.IsNullOrEmpty())
            {
                return query.OrderByDescending(c => c.CreationTime);
            }
            else
            {
                return base.ApplySorting(query, input);
            }
        }
    }
}