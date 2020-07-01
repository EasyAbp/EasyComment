using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Route("/widgets/easyComment")]
    public class CommentViewerWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentViewer")]
        public IActionResult ShowCommentViewer(CommentViewerWidgetParameter viewModel)
        {
            return ViewComponent("CommentViewerWidget", viewModel);
        }
    }
}