using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.EasyComment.Pages
{
    public class IndexModel : EasyCommentPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}