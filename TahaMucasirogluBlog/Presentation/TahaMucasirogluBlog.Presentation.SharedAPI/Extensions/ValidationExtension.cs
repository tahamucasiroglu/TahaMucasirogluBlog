using FluentValidation;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPost;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPostCategory;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.BlogPostTag;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Category;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Comment;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.Tag;
using TahaMucasirogluBlog.Application.Validation.Concrete.Blog.User;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Info;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Application.Validation.Concrete.Cv.SubSkill;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    static public class ValidationExtension
    {
        public static void AddFluentValidationValidators(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<AddBlogPostCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddBlogPostCategoryListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostCategoryListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostCategoryListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddBlogPostDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddBlogPostListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddBlogPostTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddBlogPostTagListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateBlogPostTagListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteBlogPostTagListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddCategoryListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCategoryListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCategoryDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCategoryListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddCommentDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddCommentListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCommentDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateCommentListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCommentDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteCommentListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceTechnologyListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTechnologyListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTechnologyDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTechnologyListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddExperienceTypeListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateExperienceTypeListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTypeDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteExperienceTypeListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddInfoListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateInfoListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteInfoDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteInfoListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSkillListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddSubSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateSubSkillListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSubSkillDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteSubSkillListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddTagListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateTagListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteTagDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteTagListDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<AddUserDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<AddUserListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserListDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteUserDTOValidation>();
            services.AddValidatorsFromAssemblyContaining<DeleteUserListDTOValidation>();

        }
    }
}
