using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration
{
    public class TagConfiguration : EntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);


            // Name: zorunlu, maksimum 100 karakter
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Slug: zorunlu, maksimum 100 karakter
            builder.Property(t => t.Slug)
                   .IsRequired()
                   .HasMaxLength(100);

            // Slug benzersiz indeks
            builder.HasIndex(t => t.Slug)
                   .IsUnique();

            // İlişki: Tag → BlogPostTag (join entity)
            builder.HasMany(t => t.PostTags)
                   .WithOne(pt => pt.Tag)
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
