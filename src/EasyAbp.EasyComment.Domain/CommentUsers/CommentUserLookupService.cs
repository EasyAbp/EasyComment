using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.EasyComment.CommentUsers
{
    public class CommentUserLookupService : UserLookupService<CommentUser, ICommentUserRepository>, ICommentUserLookupService
    {
        public CommentUserLookupService(ICommentUserRepository userRepository, IUnitOfWorkManager unitOfWorkManager)
            : base(userRepository, unitOfWorkManager)
        {
        }

        protected override CommentUser CreateUser(IUserData externalUser)
        {
            return new CommentUser(externalUser);
        }
    }
}