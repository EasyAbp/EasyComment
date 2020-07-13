using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsZoneWidget
{
    [Route("/widgets/easyComment")]
    public class CommentZoneWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentsZone")]
        public IActionResult ShowCommentsZone(CommentsZoneWidgetParameter parameter)
        {
            return ViewComponent("CommentsZoneWidget", parameter);
        } 
    }
}