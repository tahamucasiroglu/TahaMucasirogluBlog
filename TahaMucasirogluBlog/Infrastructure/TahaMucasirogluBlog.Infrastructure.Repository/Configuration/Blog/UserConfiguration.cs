using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Configuration.Blog
{
    public class UserConfiguration : BlogEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);


            // FirstName alanı: zorunlu, max 50 karakter
            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            // LastName alanı: zorunlu, max 50 karakter
            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            // Email alanı: zorunlu, max 200 karakter ve benzersiz index
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.HasIndex(u => u.Email)
                   .IsUnique();

            // PasswordHash: zorunlu, uygun uzunlukta
            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(200);

            // Navigasyon: User → BlogPost (1‑n)
            builder.HasMany(u => u.Posts)
                   .WithOne(bp => bp.User)
                   .HasForeignKey(bp => bp.AuthorId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
