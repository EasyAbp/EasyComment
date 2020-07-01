using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentEditor",
        ScriptFiles = new[] {"/Pages/Shared/Components/CommentEditorWidget/Default.js"}
    )]
    public class CommentEditorWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentEditorWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid? id, bool showLabel, bool editModel)
        {
            var viewModel = new CommentEditorViewModel
            {
                ShowLabel = showLabel,
                EditModel = editModel,
            };
            if (id.HasValue)
            {
                var comment = await _service.GetAsync(id.Value);
                viewModel.Content = comment.Content;
            }

            return View(viewModel);
        }
    }
}