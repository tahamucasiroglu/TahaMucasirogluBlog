using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TahaMucasiroglu.Domain.Entities.Abstract;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Infrastructure.Repository.Configuration.Base
{
    /// <summary>
    /// MainEntity tipi için özel ek yapılandırmalar.
    /// Şu anlık ek yapılandırmaya gerek duyulmadı ancak genişletilebilir.
    /// </summary>
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //Sorguda sık kullanılanları index yapma

            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.IsDeleted);
            builder.HasIndex(e => new { e.Id, e.IsDeleted });

            // Birincil anahtar tanımı
            builder.HasKey(e => e.Id);

            // Kayıt tarihi (otomatik, zorunlu)
            builder.Property(e => e.InsertedAt)
                   .RequiredDateTimeConfigs(columnType: "datetime2", precision: 0, defaultNow: true);

            // Güncelleme tarihi (opsiyonel)
            builder.Property(e => e.UpdatedAt)
                   .NullableDateTimeConfigs(columnType: "datetime2", precision: 0);

            // Silinme tarihi (opsiyonel, yumuşak silme için)
            builder.Property(e => e.DeletedAt)
                   .NullableDateTimeConfigs(columnType: "datetime2", precision: 0);

            // Kaydı oluşturan kullanıcı (zorunlu)
            builder.Property(e => e.InsertedBy)
                   .RequiredGuidConfigs();

            // Kaydı güncelleyen kullanıcı (opsiyonel)
            builder.Property(e => e.UpdatedBy)
                   .NullableGuidConfigs();

            // Kaydı silen kullanıcı (opsiyonel)
            builder.Property(e => e.DeletedBy)
                   .NullableGuidConfigs();

            // Yumuşak silme bayrağı
            builder.Property(e => e.IsDeleted)
                   .RequiredBoolConfigs(defaultVal: false);

            // Global filtre: Silinmiş kayıtları sorgulardan otomatik çıkarır
            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
