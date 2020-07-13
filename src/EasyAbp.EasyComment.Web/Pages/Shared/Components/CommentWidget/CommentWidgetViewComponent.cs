using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentWidget
{
    [Widget(
        StyleFiles = new []{"/Pages/Shared/Components/CommentWidget/Default.css"}
        )]
    public class CommentWidgetViewComponent : AbpViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CommentWidgetParameter parameter)
        {
            return View(new CommentWidgetViewModel(parameter.Comment));
        }  
    }
}