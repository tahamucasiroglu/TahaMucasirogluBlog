﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Infrastructure.BlogRepository.Configuration.Base;

namespace TahaMucasiroglu.Infrastructure.BlogRepository.Configuration
{
    public class TagConfiguration : BlogEntityConfiguration<Tag>
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
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
