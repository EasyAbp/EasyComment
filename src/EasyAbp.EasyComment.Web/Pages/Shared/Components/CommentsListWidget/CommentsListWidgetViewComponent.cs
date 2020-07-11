using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentsListWidget
{
    [Widget]
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
                SkipCount = parameter.SkipCount,
                MaxResultCount = parameter.MaxResultCount,
                Sorting = parameter.Sorting
            });

            bool hasMore = parameter.LoadedCount + output.Items.Count < output.TotalCount;
            return View(new CommentsListWidgetViewModel(output.Items, output.TotalCount, hasMore));
        }  
    }
}