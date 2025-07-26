using AutoMapper;
using TahaMucasiroglu.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;

namespace TahaMucasiroglu.Application.Mapper.MapProfile.Blog
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {
            CreateMap<AddCommentDTO, Comment>().DefaultAddMapConfig();
            CreateMap<UpdateCommentDTO, Comment>().DefaultUpdateMapConfig();
            CreateMap<DeleteCommentDTO, Comment>().DefaultDeleteMapConfig();
            CreateMap<Comment, GetCommentDTO>();
        }
    }
}
