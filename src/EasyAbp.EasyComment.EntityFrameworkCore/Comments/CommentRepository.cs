using System;
using EasyAbp.EasyComment.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.EasyComment.Comments
{
    public class CommentRepository : EfCoreRepository<IEasyCommentDbContext, Comment, Guid>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<EasyCommentDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}