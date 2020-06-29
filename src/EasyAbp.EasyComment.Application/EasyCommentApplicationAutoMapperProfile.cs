using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using AutoMapper;

namespace EasyAbp.EasyComment
{
    public class EasyCommentApplicationAutoMapperProfile : Profile
    {
        public EasyCommentApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.CreatorName, opt => opt.Ignore())
                ;
            CreateMap<CreateUpdateCommentDto, Comment>(MemberList.Source);
        }
    }
}
