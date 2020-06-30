using System;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentViewer"
    )]
    public class CommentViewerWidgetViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(Guid id, string content)
        {
            return View(new CommentViewerViewModel
            {
                Id = id,
                Content = content,
            });
        } 
    }
}