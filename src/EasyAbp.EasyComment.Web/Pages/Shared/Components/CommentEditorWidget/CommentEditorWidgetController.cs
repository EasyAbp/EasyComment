using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    [Route("/widgets/easyComment")]
    public class CommentEditorWidgetController : EasyCommentController
    {
        [HttpGet]
        [Route("showCommentEditor")]
        public IActionResult ShowCommentEditor(Guid? id, bool showLabel, bool editModel)
        {
            return ViewComponent("CommentEditorWidget", new {id, showLabel, editModel});
        } 
    }
}