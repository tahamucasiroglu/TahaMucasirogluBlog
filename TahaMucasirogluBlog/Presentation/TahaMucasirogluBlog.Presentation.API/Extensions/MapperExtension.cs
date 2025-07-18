﻿using TahaMucasirogluBlog.Application.Mapper.MapProfile.Blog;
using TahaMucasirogluBlog.Application.Mapper.MapProfile.Cv;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class MapperExtension
    {
        public static void AddMapperMapProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BlogPostCategoryMapProfile));
            services.AddAutoMapper(typeof(BlogPostMapProfile));
            services.AddAutoMapper(typeof(BlogPostTagMapProfile));
            services.AddAutoMapper(typeof(CategoryMapProfile));
            services.AddAutoMapper(typeof(CommentMapProfile));
            services.AddAutoMapper(typeof(TagMapProfile));
            services.AddAutoMapper(typeof(UserMapProfile));
            services.AddAutoMapper(typeof(CvResponseDTOMappingProfile));
        }
    }
}
