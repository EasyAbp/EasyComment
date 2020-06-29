using System.Threading.Tasks;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment
{
    public class IndexModel : EasyCommentPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
