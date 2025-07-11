using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPost;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPostCategory;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.BlogPostTag;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Category;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Comment;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.User;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.BlogPostCategory;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class ValidationExtension
    {
        public static void AddFluentValidationValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AddBlogPostCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostCategoryDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddBlogPostDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddBlogPostTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostTagDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCategoryDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddCommentDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCommentDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCommentDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteTagDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddUserDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteUserDTOValidation>();

        }
    }
}
