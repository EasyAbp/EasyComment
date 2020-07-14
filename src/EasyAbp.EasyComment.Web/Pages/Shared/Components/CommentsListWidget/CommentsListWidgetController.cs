using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    [Route("/widgets/easyComment")]
    public class CommentsListWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentsList")]
        public IActionResult ShowCommentsList(CommentsListWidgetParameter parameter)
        {
            return ViewComponent("CommentsListWidget", parameter);
        }
    }
}