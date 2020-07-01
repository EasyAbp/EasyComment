using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    [Route("/widgets/easyComment")]
    public class CommentEditorWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentEditor")]
        public IActionResult ShowCommentEditor(CommentEditorWidgetParameter parameter)
        {
            return ViewComponent("CommentEditorWidget", parameter);
        } 
    }
}