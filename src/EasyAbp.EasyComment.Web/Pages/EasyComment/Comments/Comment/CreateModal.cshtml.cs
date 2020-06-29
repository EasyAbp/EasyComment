using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment.ViewModels;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment
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