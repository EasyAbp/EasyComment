using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.EasyComment.Comments
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
    }
}