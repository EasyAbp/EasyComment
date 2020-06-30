using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/comments",
        ScriptFiles = new[]{"/Pages/Shared/Components/CommentsWidget/Default.js"},
        StyleFiles = new[] {"/Pages/Shared/Components/CommentsWidget/Default.css"}
    )]
    public class CommentsWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentsWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(string itemType, string itemKey)
        {
            var comments = await _service.GetListAsync(new GetListInput
            {
                ItemType = itemType,
                ItemKey = itemKey,
            });
            return View(new CommentsWidgetViewModel
            {
                ItemType = itemType,
                ItemKey = itemKey,
                Comments = comments,
            });
        }
    }
}