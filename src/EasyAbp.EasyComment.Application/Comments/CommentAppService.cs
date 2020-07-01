using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Permissions;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Threading;
using Volo.Abp.Users;

namespace EasyAbp.EasyComment.Comments
{
    public class CommentAppService : CrudAppService<Comment, CommentDto, Guid, GetListInput, CreateUpdateCommentDto, CreateUpdateCommentDto>,
        ICommentAppService
    {
        protected override string CreatePolicyName { get; set; } = EasyCommentPermissions.Comment.Create;
        protected override string UpdatePolicyName { get; set; } = EasyCommentPermissions.Comment.Update;
        protected override string DeletePolicyName { get; set; } = EasyCommentPermissions.Comment.Delete;
        private readonly ICommentRepository _repository;
        private readonly IExternalUserLookupServiceProvider _userLookupServiceProvider;

        public CommentAppService(ICommentRepository repository, IExternalUserLookupServiceProvider userLookupServiceProvider) : base(repository)
        {
            _repository = repository;
            _userLookupServiceProvider = userLookupServiceProvider;
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

        protected override CommentDto MapToGetListOutputDto(Comment entity)
        {
            var dto = base.MapToGetListOutputDto(entity);
            var creator = AsyncHelper.RunSync(() => _userLookupServiceProvider.FindByIdAsync(entity.CreatorId.GetValueOrDefault()));
            dto.CreatorName = creator.Name;
            if (entity.ReplyTo.HasValue)
            {
                var replyTo = AsyncHelper.RunSync(() => _userLookupServiceProvider.FindByIdAsync(entity.ReplyTo.GetValueOrDefault()));
                dto.ReplyToName = replyTo.Name;
            }

            return dto;
        }

        [Authorize]
        public virtual async Task<CommentDto> AddCommentAsync(CreateUpdateCommentDto input)
        {
            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        [Authorize]
        public virtual async Task<CommentDto> UpdateContentAsync(UpdateContentInput input)
        {
            var comment = await GetEntityByIdAsync(input.Id);
            if (comment.CreatorId != CurrentUser.GetId() && !await AuthorizationService.IsGrantedAsync(EasyCommentPermissions.Comment.Update))
            {
                throw new BusinessException(EasyCommentErrorCodes.OnlyOwnedCommentEditAllowed);
            }

            comment.SetContent(input.Content);
            return MapToGetOutputDto(comment);
        }

        [Authorize]
        public virtual async Task RemoveCommentAsync(Guid id)
        {
            var comment = await GetEntityByIdAsync(id);
            if (comment.CreatorId != CurrentUser.GetId() && !await AuthorizationService.IsGrantedAsync(EasyCommentPermissions.Comment.Delete))
            {
                throw new BusinessException(EasyCommentErrorCodes.OnlyOwnedCommentDeleteAllowed);
            }

            await DeleteByIdAsync(id);
        }
    }
}