using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentEditor",
        ScriptFiles = new[]
        {
            "/Pages/Shared/Components/CommentEditorWidget/Default.js",
            "/Pages/Shared/Components/CommentEditorWidget/Action.js",
        },
        StyleFiles = new []{"/Pages/Shared/Components/CommentEditorWidget/Default.css"}
    )]
    public class CommentEditorWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentEditorWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentEditorWidgetParameter parameter)
        {
            if (parameter.Id.HasValue)
            {
                var comment = await _service.GetAsync(parameter.Id.Value);
                parameter.Content = comment.Content;
            }

            return View(new CommentEditorWidgetViewModel
            {
                Id = parameter.Id,
                Label = parameter.Label,
                Content = parameter.Content,
                EditModel = parameter.EditModel,
            });
        }
    }
}