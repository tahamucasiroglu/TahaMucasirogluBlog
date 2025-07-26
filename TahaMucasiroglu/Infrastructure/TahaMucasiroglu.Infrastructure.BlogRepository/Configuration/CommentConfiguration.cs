using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Configuration
{
    public class CommentConfiguration : BlogEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);


            // PostId → BlogPost (zorunlu ilişki, gönderi silinince yorumlar silinsin)
            builder.HasOne(c => c.BlogPost)
                   .WithMany(bp => bp.Comments)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.NoAction);

            // ParentComment (self-referencing) – nullable, cevaplar için
            builder.HasOne(c => c.ParentComment)
                   .WithMany(pc => pc.Replies)
                   .HasForeignKey(c => c.ParentCommentId)
                   .OnDelete(DeleteBehavior.NoAction); // silince alt yorumları bozmamak için

            // Content: zorunlu alan
            builder.Property(c => c.Content)
                   .IsRequired();

            // IsApproved: zorunlu boolean
            builder.Property(c => c.IsApproved)
                   .IsRequired();
        }
    }
}
