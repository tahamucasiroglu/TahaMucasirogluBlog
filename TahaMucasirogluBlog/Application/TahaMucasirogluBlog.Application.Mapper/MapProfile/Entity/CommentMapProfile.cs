using AutoMapper;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
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
