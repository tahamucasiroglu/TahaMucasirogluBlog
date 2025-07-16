using Microsoft.EntityFrameworkCore;
using TahaMucasirogluBlog.Application.Managers.LoggerManager;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Main;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Main;
using TahaMucasirogluBlog.Service.Cv.Abstract;
using TahaMucasirogluBlog.Service.Cv.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract;
using TahaMucasirogluBlog.Service.Database.Concrete;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {
           



            builder.Services.AddScoped<IBlogPostCategoryRepository, BlogPostCategoryRepository>();
            builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            builder.Services.AddScoped<IBlogPostTagRepository, BlogPostTagRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
            builder.Services.AddScoped<IExperienceTechnologyRepository, ExperienceTechnologyRepository>();
            builder.Services.AddScoped<IExperienceTypeRepository, ExperienceTypeRepository>();
            builder.Services.AddScoped<IInfoRepository, InfoRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ISocialLinkRepository, SocialLinkRepository>();
            builder.Services.AddScoped<ISubSkillRepository, SubSkillRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();





            builder.Services.AddScoped<IBlogPostCategoryDatabaseService, BlogPostCategoryDatabaseService>();
            builder.Services.AddScoped<IBlogPostDatabaseService, BlogPostDatabaseService>();
            builder.Services.AddScoped<IBlogPostTagDatabaseService, BlogPostTagDatabaseService>();
            builder.Services.AddScoped<ICategoryDatabaseService, CategoryDatabaseService>();
            builder.Services.AddScoped<ICommentDatabaseService, CommentDatabaseService>();
            builder.Services.AddScoped<IExperienceDatabaseService, ExperienceDatabaseService>();
            builder.Services.AddScoped<IExperienceTechnologyDatabaseService, ExperienceTechnologyDatabaseService>();
            builder.Services.AddScoped<IExperienceTypeDatabaseService, ExperienceTypeDatabaseService>();
            builder.Services.AddScoped<IInfoDatabaseService, InfoDatabaseService>();
            builder.Services.AddScoped<ISkillDatabaseService, SkillDatabaseService>();
            builder.Services.AddScoped<ISocialLinkDatabaseService, SocialLinkDatabaseService>();
            builder.Services.AddScoped<ISubSkillDatabaseService, SubSkillDatabaseService>();
            builder.Services.AddScoped<ITagDatabaseService, TagDatabaseService>();
            builder.Services.AddScoped<IUserDatabaseService, UserDatabaseService>();




            builder.Services.AddScoped<ICvService, CvService>();



        }
    }
}
