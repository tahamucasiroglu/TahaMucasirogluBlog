using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Concrete;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Extensions
{
    static public class ScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {

            

            builder.Services.AddScoped<IBlogPostApiConnectionService, BlogPostApiConnectionService>();
            builder.Services.AddScoped<IBlogPostTagApiConnectionService, BlogPostTagApiConnectionService>();
            builder.Services.AddScoped<IBlogPostCategoryApiConnectionService, BlogPostCategoryApiConnectionService>();
            builder.Services.AddScoped<ICategoryApiConnectionService, CategoryApiConnectionService>();
            builder.Services.AddScoped<ICommentApiConnectionService, CommentApiConnectionService>();
            builder.Services.AddScoped<ITagApiConnectionService, TagApiConnectionService>();
            builder.Services.AddScoped<IUserApiConnectionService, UserApiConnectionService>();


        }
    }
}
