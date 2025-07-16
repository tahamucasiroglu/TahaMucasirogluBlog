using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog
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
