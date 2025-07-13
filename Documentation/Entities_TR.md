# TahaMucasirogluBlog.Domain.Entities - Entity Projesi Dokümantasyonu

## Proje Amacı

Bu proje, uygulamanın veritabanı tablolarını temsil eden entity sınıflarını içerir. Entity Framework Core Code-First yaklaşımı ile veritabanı tablolarının C# sınıfları olarak tanımlandığı projedir.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.Entities/
├── Abstract/
│   └── IEntity.cs
├── Base/
│   └── Entity.cs
└── Concrete/
    ├── BlogPost.cs
    ├── BlogPostCategory.cs
    ├── BlogPostTag.cs
    ├── Category.cs
    ├── Comment.cs
    ├── Experience.cs
    ├── ExperienceTechnology.cs
    ├── ExperienceType.cs
    ├── Info.cs
    ├── Skill.cs
    ├── SocialLink.cs
    ├── SubSkill.cs
    ├── Tag.cs
    └── User.cs
```

## Temel Bileşenler

### Abstract/IEntity.cs
Tüm entity'lerin uygulaması gereken temel interface. Her entity'nin sahip olması gereken ortak özellikleri tanımlar.

### Base/Entity.cs
IEntity interface'ini implement eden abstract base class. Tüm entity'lerde ortak olan alanları içerir:
- **Id** (Guid) - Benzersiz tanımlayıcı
- **CreatedDate** - Oluşturulma tarihi
- **UpdatedDate** - Güncellenme tarihi
- **IsDeleted** - Soft delete için kullanılan alan

## Entity Sınıfları

### Blog Yönetimi Entity'leri

#### BlogPost.cs
Blog yazılarını temsil eder.
- Başlık, içerik, özet
- Yayın durumu ve tarihi
- Yazar bilgisi (User ilişkisi)
- Kategori ve etiket ilişkileri

#### Category.cs
Blog kategorilerini temsil eder.
- Kategori adı ve açıklaması
- SEO için slug alanı
- Alt kategoriler için parent-child ilişkisi

#### Tag.cs
Blog etiketlerini temsil eder.
- Etiket adı
- SEO için slug alanı
- Blog yazıları ile many-to-many ilişki

#### Comment.cs
Blog yorumlarını temsil eder.
- Yorum içeriği
- Yorumcu bilgileri
- BlogPost ile ilişki
- Onay durumu

### İlişki Tabloları

#### BlogPostCategory.cs
BlogPost ve Category arasındaki many-to-many ilişkiyi yönetir.

#### BlogPostTag.cs
BlogPost ve Tag arasındaki many-to-many ilişkiyi yönetir.

### CV/Özgeçmiş Entity'leri

#### Experience.cs
İş deneyimlerini temsil eder.
- Şirket adı, pozisyon
- Başlangıç ve bitiş tarihleri
- Açıklama ve sorumluluklar
- ExperienceType ilişkisi

#### ExperienceType.cs
Deneyim tiplerini temsil eder (İş, Eğitim, Sertifika vb.)

#### ExperienceTechnology.cs
Deneyimlerde kullanılan teknolojileri temsil eder.
- Experience ile many-to-many ilişki

#### Skill.cs
Yetenekleri temsil eder.
- Yetenek adı ve seviyesi
- Kategori bilgisi
- SubSkill'ler ile one-to-many ilişki

#### SubSkill.cs
Alt yetenekleri temsil eder.
- Skill ile parent-child ilişkisi
- Yetenek seviyesi

### Diğer Entity'ler

#### User.cs
Sistem kullanıcılarını temsil eder.
- Kullanıcı adı, email, şifre hash
- Profil bilgileri
- Rol ve yetki bilgileri

#### Info.cs
Genel bilgileri saklar.
- Site ayarları
- İletişim bilgileri
- Hakkımda metinleri

#### SocialLink.cs
Sosyal medya bağlantılarını temsil eder.
- Platform adı
- URL
- İkon bilgisi
- Sıralama

## Entity İlişkileri

### One-to-Many İlişkiler
- User → BlogPost (Bir kullanıcının birden fazla blog yazısı)
- BlogPost → Comment (Bir blog yazısının birden fazla yorumu)
- Skill → SubSkill (Bir yeteneğin birden fazla alt yeteneği)
- Category → Category (Self-referencing için alt kategoriler)

### Many-to-Many İlişkiler
- BlogPost ↔ Category (BlogPostCategory üzerinden)
- BlogPost ↔ Tag (BlogPostTag üzerinden)
- Experience ↔ Technology (ExperienceTechnology üzerinden)

## Önemli Özellikler

1. **Soft Delete**: IsDeleted alanı ile kayıtlar fiziksel olarak silinmez
2. **Audit Fields**: CreatedDate ve UpdatedDate ile kayıt takibi
3. **Guid Primary Keys**: Dağıtık sistemler için uygun
4. **Navigation Properties**: Entity Framework için ilişki tanımlamaları
5. **Data Annotations**: Validation ve constraint tanımlamaları

## Kullanım Örneği

```csharp
// Yeni bir blog yazısı oluşturma
var blogPost = new BlogPost
{
    Title = "Clean Architecture Nedir?",
    Content = "İçerik...",
    Summary = "Özet...",
    UserId = currentUserId,
    IsPublished = true,
    PublishedDate = DateTime.Now
};

// Kategori ilişkisi ekleme
var blogPostCategory = new BlogPostCategory
{
    BlogPostId = blogPost.Id,
    CategoryId = categoryId
};
```

## Best Practices

1. Entity'ler sadece veri taşımalı, iş mantığı içermemeli
2. Navigation property'ler lazy loading için virtual tanımlanmalı
3. İlişkiler Fluent API ile Infrastructure katmanında configure edilmeli
4. Entity'ler Domain katmanında kalmalı, dış katmanlara expose edilmemeli