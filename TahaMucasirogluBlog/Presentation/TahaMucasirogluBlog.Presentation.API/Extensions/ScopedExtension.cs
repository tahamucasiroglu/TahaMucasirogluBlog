using Microsoft.EntityFrameworkCore;
using TahaMucasirogluBlog.Application.Managers.LoggerManager;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete;
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
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IBlogPostCategoryDatabaseService, BlogPostCategoryDatabaseService >();
            builder.Services.AddScoped<IBlogPostDatabaseService, BlogPostDatabaseService >();
            builder.Services.AddScoped<IBlogPostTagDatabaseService, BlogPostTagDatabaseService >();
            builder.Services.AddScoped<ICategoryDatabaseService, CategoryDatabaseService >();
            builder.Services.AddScoped<ICommentDatabaseService, CommentDatabaseService >();
            builder.Services.AddScoped<ITagDatabaseService, TagDatabaseService >();
            builder.Services.AddScoped<IUserDatabaseService, UserDatabaseService >();




        }
    }
}
