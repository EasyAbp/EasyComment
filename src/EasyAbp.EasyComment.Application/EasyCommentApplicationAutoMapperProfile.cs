using EasyAbp.EasyComment.Comments;
using EasyAbp.EasyComment.Comments.Dtos;
using AutoMapper;
using EasyAbp.EasyComment.CommentUsers;

namespace EasyAbp.EasyComment
{
    public class EasyCommentApplicationAutoMapperProfile : Profile
    {
        public EasyCommentApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CommentUser, CommentUserDto>();
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.CreateUser, opt => opt.Ignore())
                .ForMember(dest => dest.ReplyToUser, opt => opt.Ignore())
                ;
            CreateMap<CreateUpdateCommentDto, Comment>(MemberList.Source);
        }
    }
}
