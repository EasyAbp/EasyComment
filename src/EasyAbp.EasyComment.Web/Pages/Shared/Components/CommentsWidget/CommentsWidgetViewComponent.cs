using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Pagination;
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

        public async Task<IViewComponentResult> InvokeAsync(CommentsWidgetParameter parameter)
        {
            var comments = await _service.GetListAsync(new GetListInput
            {
                ItemType = parameter.ItemType,
                ItemKey = parameter.ItemKey,
                SkipCount = (parameter.Page - 1) * parameter.CommentsCountPerPage,
                MaxResultCount = parameter.CommentsCountPerPage,
            });
            
            var pagerModel = new PagerModel(comments.TotalCount, 
                parameter.CommentsCountPerPage,
                parameter.Page,
                parameter.CommentsCountPerPage,
                String.Empty,    // we will use js to handle navigation
                parameter.Sorting
                );
            
            return View(new CommentsWidgetViewModel
            {
                ItemType = parameter.ItemType,
                ItemKey = parameter.ItemKey,
                Comments = comments,
                PagerModel = pagerModel,
            });
        }
    }
}