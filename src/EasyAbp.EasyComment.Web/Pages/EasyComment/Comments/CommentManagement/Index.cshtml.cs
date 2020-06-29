using System.Threading.Tasks;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.CommentManagement
{
    public class IndexModel : EasyCommentPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
