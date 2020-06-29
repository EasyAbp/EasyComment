using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment.ViewModels;

namespace EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment
{
    public class EditModalModel : EasyCommentPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCommentViewModel ViewModel { get; set; }

        private readonly ICommentAppService _service;

        public EditModalModel(ICommentAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CommentDto, CreateEditCommentViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCommentViewModel, CreateUpdateCommentDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}