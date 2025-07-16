using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.BlogRepository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.BlogRepository.Configuration
{
    public class BlogPostConfiguration : BlogEntityConfiguration<BlogPost>
    {
        public override void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            base.Configure(builder);

            // AuthorId -> User ilişkisi
            builder.Property(bp => bp.AuthorId)
                .IsRequired();

            builder.HasOne(bp => bp.User)
                .WithMany()
                .HasForeignKey(bp => bp.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Başlık
            builder.Property(bp => bp.Title)
                .IsRequired()
                .HasMaxLength(200);

            // Slug
            builder.Property(bp => bp.Slug)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(bp => bp.Slug).IsUnique();

            // İçerik
            builder.Property(bp => bp.Content)
                .IsRequired();

            // ViewCount
            builder.Property(bp => bp.ViewCount)
                .HasDefaultValue(0L)
                .IsRequired();

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Posts)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.AuthorId);

        }
    }
}
