using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.EasyComment.EntityFrameworkCore.Comments
{
    public class CommentRepositoryTests : EasyCommentEntityFrameworkCoreTestBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentRepositoryTests()
        {
            _commentRepository = GetRequiredService<ICommentRepository>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
