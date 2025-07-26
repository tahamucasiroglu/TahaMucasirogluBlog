using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Configuration
{
    public class CategoryConfiguration : BlogEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);


            // ParentCategoryId → Category (self-referencing), nullable FK
            builder.HasOne(c => c.ParrentCategory)
                   .WithMany(pc => pc.SubCategories) // alt kategoriler koleksiyonu
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Name: zorunlu, max 100 karakter
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Slug: zorunlu, max 100 karakter, unique index
            builder.Property(c => c.Slug)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.HasIndex(c => c.Slug)
                   .IsUnique();

            // Navigasyon için koleksiyon adı (Category sınıfında eklenmeli)
        }
    }
}
