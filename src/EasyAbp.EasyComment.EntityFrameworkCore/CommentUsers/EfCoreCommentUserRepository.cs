using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.EasyComment.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace EasyAbp.EasyComment.CommentUsers
{
    public class EfCoreCommentUserRepository : EfCoreUserRepositoryBase<IEasyCommentDbContext, CommentUser>, ICommentUserRepository
    {
        public EfCoreCommentUserRepository(IDbContextProvider<IEasyCommentDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }
    }
}
