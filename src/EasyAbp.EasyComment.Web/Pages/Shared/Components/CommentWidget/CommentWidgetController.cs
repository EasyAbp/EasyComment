using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    [Route("/widgets/easyComment")]
    public class CommentWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("comments")]
        public IActionResult Comments(string itemType, string itemKey)
        {
            return ViewComponent("CommentWidget", new {itemType, itemKey});
        } 
    }
}