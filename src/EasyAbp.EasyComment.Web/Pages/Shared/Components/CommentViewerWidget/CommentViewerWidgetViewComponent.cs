using EasyAbp.EasyComment.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Widget]
    public class CommentViewerWidgetViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(CommentViewerViewModel viewModel)
        {
            return View(viewModel);
        } 
    }
}