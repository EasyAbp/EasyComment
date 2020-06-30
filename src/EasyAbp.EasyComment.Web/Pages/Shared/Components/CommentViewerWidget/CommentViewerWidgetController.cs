using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Route("/widgets/easyComment")]
    public class CommentViewerWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentViewer")]
        public IActionResult ShowCommentViewer(Guid id, string content)
        {
            return ViewComponent("CommentViewerViewModel", new {id, content});
        }
    }
}