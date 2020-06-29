using System.Threading.Tasks;
using EasyAbp.EasyComment.Localization;
using EasyAbp.EasyComment.Permissions;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.EasyComment.Web.Menus
{
    public class EasyCommentMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<EasyCommentResource>();
             //Add main menu items.

            if (await context.IsGrantedAsync(EasyCommentPermissions.Comment.Default))
            {
                context.Menu.AddItem(
                    new ApplicationMenuItem("CommentManagement", l["Menu:CommentManagement"], "/EasyComment/Comments/CommentManagement")
                );
            }
        }
    }
}
