using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.CommentManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.CommentManagement
{
    public class CreateModalModel : EasyCommentPageModel
    {
        [BindProperty]
        public CreateEditCommentViewModel ViewModel { get; set; }

        private readonly ICommentAppService _service;

        public CreateModalModel(ICommentAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCommentViewModel, CreateUpdateCommentDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}