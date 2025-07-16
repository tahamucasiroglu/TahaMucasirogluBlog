using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.BlogRepository.Configuration
{
    public class BlogPostTagConfiguration : BlogEntityConfiguration<BlogPostTag>
    {
        public override void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            base.Configure(builder);


            // Composite primary key
            builder.HasKey(pt => new { pt.PostId, pt.TagId });
            builder.HasKey(pt =>  pt.TagId);
            builder.HasKey(pt => pt.PostId);

            // Foreign key: PostId → BlogPost
            builder.HasOne(pt => pt.BlogPost)
                   .WithMany(bp => bp.PostTags)
                   .HasForeignKey(pt => pt.PostId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Foreign key: TagId → Tag
            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.PostTags)
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
