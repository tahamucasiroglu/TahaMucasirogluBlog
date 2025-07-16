using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Blog
{
    public class BlogPostCategoryConfiguration : BlogEntityConfiguration<BlogPostCategory>
    {
        public override void Configure(EntityTypeBuilder<BlogPostCategory> builder)
        {
            base.Configure(builder);


            // Composite primary key: PostId + CategoryId
            builder.HasKey(pc => new { pc.PostId, pc.CategoryId });
            builder.HasKey(pc =>  pc.CategoryId );
            builder.HasKey(pc => pc.PostId );

            // Foreign key PostId → BlogPost
            builder.HasOne(pc => pc.BlogPost)
                .WithMany(bp => bp.PostCategories)
                .HasForeignKey(pc => pc.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            // Foreign key CategoryId → Category
            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.PostCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
