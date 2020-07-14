using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentsList",
        ScriptFiles = new[] { "/Pages/Shared/Components/CommentsListWidget/Default.js"}, 
        StyleFiles = new []{"/Pages/Shared/Components/CommentsListWidget/Default.css"}
        )]
    public class CommentsListWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentsListWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentsListWidgetParameter parameter)
        {
            var output = await _service.GetListAsync(new GetListInput
            {
                ItemType = parameter.ItemType,
                ItemKey = parameter.ItemKey,
                SkipCount = parameter.LoadedCount,
                MaxResultCount = parameter.MaxResultCount,
                Sorting = parameter.Sorting
            });

            return View(new CommentsListWidgetViewModel(output.Items, parameter.LoadedCount + output.Items.Count, output.TotalCount));
        }  
    }
}