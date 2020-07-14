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
        ScriptFiles = new[] {"/Pages/Shared/Components/CommentViewerWidget/Default.js"},
        StyleFiles = new[] {"/Pages/Shared/Components/CommentViewerWidget/Default.css"}
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
            CommentViewerWidgetViewModel vm;
            if (parameter.FromServer)
            {
                var comment = await _service.GetAsync(parameter.Id);
                vm = new CommentViewerWidgetViewModel(comment.Id, comment.Content);
            }
            else
            {
                vm = new CommentViewerWidgetViewModel(parameter.Id, parameter.Content);
            }

            return View(vm);
        }
    }
}