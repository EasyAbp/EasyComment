using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentViewer",
        ScriptFiles = new[] {"/Pages/Shared/Components/CommentViewerWidget/Default.js"}
    )]
    public class CommentViewerWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentViewerWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentViewerWidgetParameter parameter)
        {
            if (parameter.FromServer)
            {
                var comment = await _service.GetAsync(parameter.Id);
                parameter.Content = comment.Content;
            }

            return View(new CommentViewerWidgetViewModel
            {
                Id = parameter.Id,
                Content = parameter.Content,
            });
        }
    }
}