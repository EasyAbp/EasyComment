using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsWidget
{
    [Route("/widgets/easyComment")]
    public class CommentsWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("comments")]
        public IActionResult Comments(CommentsWidgetParameter parameter)
        {
            return ViewComponent("CommentsWidget", parameter);
        } 
    }
}