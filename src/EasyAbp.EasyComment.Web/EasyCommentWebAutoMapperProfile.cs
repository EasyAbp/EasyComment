using EasyAbp.EasyComment.Comments.Dtos;
using EasyAbp.EasyComment.Web.Pages.EasyComment.Comments.Comment.ViewModels;
using AutoMapper;

namespace EasyAbp.EasyComment.Web
{
    public class EasyCommentWebAutoMapperProfile : Profile
    {
        public EasyCommentWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CommentDto, CreateEditCommentViewModel>();
            CreateMap<CreateEditCommentViewModel, CreateUpdateCommentDto>();
        }
    }
}
