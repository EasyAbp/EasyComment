using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsZoneWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentsZone", 
        ScriptFiles = new[]
        {
            "/Pages/Shared/Components/CommentsZoneWidget/Default.js",
            "/Pages/Shared/Components/CommentsZoneWidget/Helper.js",
        }, 
        StyleFiles = new []{"/Pages/Shared/Components/CommentsZoneWidget/Default.css"}
        )]
    public class CommentsZoneWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentsZoneWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentsZoneWidgetParameter parameter)
        {
            long totalCount = await _service.GetTotalCount(new GetListInput
            {
                ItemType = parameter.ItemType,
                ItemKey = parameter.ItemKey,
            });
            
            return View(new CommentsZoneWidgetViewModel(
                parameter.ItemType,
                parameter.ItemKey,
                parameter.Sorting,
                parameter.MaxResultCount,
                totalCount
            ));
        }
    }
}