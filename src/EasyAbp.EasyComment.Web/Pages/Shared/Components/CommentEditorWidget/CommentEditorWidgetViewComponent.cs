using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentEditorWidget
{
    [Widget]
    public class CommentEditorWidgetViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(CommentEditorViewModel viewModel)
        {
            return View(viewModel);
        }  
    }
}