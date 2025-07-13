# TahaMucasirogluBlog - Kapsamlı Proje Dokümantasyonu

## 📋 İçindekiler

### 🏗️ Mimari Dokümantasyonu
- [**Architecture_TR.md**](./Architecture_TR.md) - Türkçe mimari dokümantasyonu
- [**Architecture_EN.md**](./Architecture_EN.md) - İngilizce mimari dokümantasyonu

### 🏢 Domain Katmanı
- [**Entities_TR.md**](./Entities_TR.md) - Entity sınıfları ve veritabanı tablolarını temsil eden model sınıfları
- [**DTOs_TR.md**](./DTOs_TR.md) - Veri transfer nesneleri ve katmanlar arası veri taşıma
- [**Models_TR.md**](./Models_TR.md) - Kompleks veri yapıları ve özel response modelleri
- [**Constants_TR.md**](./Constants_TR.md) - Uygulama sabitleri ve enum tanımlamaları
- [**Extensions_TR.md**](./Extensions_TR.md) - .NET tiplerini genişleten extension metodları
- [**Return_TR.md**](./Return_TR.md) - Standart response/return tipleri ve hata yönetimi

### 🔧 Application Katmanı
- [**Managers_TR.md**](./Managers_TR.md) - Cross-cutting concern'leri yöneten manager sınıfları
- [**Mapper_TR.md**](./Mapper_TR.md) - AutoMapper konfigürasyonları ve object mapping
- [**Validation_TR.md**](./Validation_TR.md) - FluentValidation ile veri doğrulama işlemleri

### 🗄️ Infrastructure Katmanı
- [**Repository_TR.md**](./Repository_TR.md) - Entity Framework ve Repository pattern implementasyonu

### 🔄 Service Katmanı
- [**DatabaseService_TR.md**](./DatabaseService_TR.md) - Veritabanı işlemleri ve business logic
- [**CvService_TR.md**](./CvService_TR.md) - CV/Özgeçmiş özel iş mantığı servisleri

### 🌐 Presentation Katmanı
- [**API_TR.md**](./API_TR.md) - RESTful API endpoint'leri ve web servisleri
- [**Clients_TR.md**](./Clients_TR.md) - MVC istemci uygulamaları (Ana Site, Admin Panel, CV Sitesi)

### 🛠️ Utils Katmanı
- [**Utils_TR.md**](./Utils_TR.md) - Yardımcı araçlar ve utility uygulamaları

## 🎯 Proje Hakkında

TahaMucasirogluBlog, Clean Architecture prensipleri doğrultusunda geliştirilmiş, modern bir blog ve CV yönetim sistemidir. Proje, .NET 8.0 teknolojisi kullanılarak geliştirilmiştir ve aşağıdaki temel özellikleri içerir:

### ✨ Ana Özellikler

- **🏗️ Clean Architecture**: Katmanlı mimari ve SOLID prensipleri
- **📝 Blog Yönetimi**: Modern blog yazma ve yönetim sistemi
- **👤 CV/Özgeçmiş Modülü**: Profesyonel CV görüntüleme ve yönetim
- **🔐 Güvenlik**: JWT authentication, authorization ve güvenlik middlewares
- **📊 Admin Paneli**: İçerik yönetimi ve sistem administrasyonu
- **🎨 Responsive Design**: Mobil uyumlu modern arayüz
- **⚡ Performans**: Caching, lazy loading ve optimizasyon teknikleri

### 🏛️ Mimari Yaklaşım

Proje, aşağıdaki katmanlardan oluşur:

1. **Domain** - İş mantığının çekirdeği, entity'ler, DTO'lar, modeller
2. **Application** - Use case'ler, mapping, validation ve manager'lar
3. **Infrastructure** - Veri erişimi, repository pattern ve external services
4. **Service** - İş mantığı servisleri ve kompleks operasyonlar
5. **Presentation** - API endpoint'leri ve web servisleri
6. **Client** - MVC web uygulamaları (Ana site, Admin, CV)
7. **Utils** - Yardımcı araçlar ve utility uygulamaları

### 🛠️ Kullanılan Teknolojiler

- **.NET 8.0** - Ana framework
- **ASP.NET Core MVC** - Web framework
- **ASP.NET Core Web API** - REST API
- **Entity Framework Core** - ORM ve veritabanı yönetimi
- **SQL Server** - Veritabanı
- **AutoMapper** - Object-to-object mapping
- **FluentValidation** - Veri doğrulama
- **Serilog** - Structured logging
- **JWT Bearer** - Authentication
- **Swagger/OpenAPI** - API dokümantasyonu

### 📚 Dokümantasyon Rehberi

Her dokümantasyon dosyası belirli bir katman veya bileşene odaklanır:

#### 🏗️ Mimari Anlayışı İçin
1. [Architecture_TR.md](./Architecture_TR.md) - Genel mimari görünüm
2. Katman bazında detay dokümantasyonları

#### 🚀 Geliştirici Rehberi İçin
1. Domain katmanı dokümantasyonları - Temel yapılar
2. Application katmanı dokümantasyonları - İş mantığı
3. Service katmanı dokümantasyonları - Servis implementasyonları

#### 🔧 Sistem Yöneticisi İçin
1. [Utils_TR.md](./Utils_TR.md) - Database kurulum ve yönetim
2. [API_TR.md](./API_TR.md) - API konfigürasyon ve deployment

### 🎓 Öğrenme Yolu

Projeyi anlamak için önerilen okuma sırası:

1. **Architecture_TR.md** - Genel mimari anlayış
2. **Entities_TR.md** - Veri modelleri ve veritabanı yapısı
3. **DTOs_TR.md** ve **Models_TR.md** - Veri transfer yapıları
4. **Repository_TR.md** - Veri erişim katmanı
5. **DatabaseService_TR.md** - İş mantığı servisleri
6. **API_TR.md** - Web API endpoint'leri
7. **Clients_TR.md** - Frontend uygulamaları

### 📋 Proje Yapısı Özeti

```
TahaMucasirogluBlog/
├── Domain/                    # İş mantığının çekirdeği
│   ├── Entities/             # Veritabanı modelleri
│   ├── DTOs/                 # Veri transfer nesneleri
│   ├── Models/               # Kompleks veri yapıları
│   ├── Constants/            # Uygulama sabitleri
│   ├── Extensions/           # Extension metodları
│   └── Return/               # Response tipleri
├── Application/              # Use case'ler ve application services
│   ├── Managers/             # Cross-cutting concerns
│   ├── Mapper/               # Object mapping
│   └── Validation/           # Veri doğrulama
├── Infrastructure/           # External concerns
│   └── Repository/           # Veri erişim katmanı
├── Service/                  # İş mantığı servisleri
│   ├── Database/             # Veritabanı servisleri
│   └── Cv/                   # CV özel servisleri
├── Presentation/             # API katmanı
│   └── API/                  # REST API endpoints
├── Client/                   # Web uygulamaları
│   ├── TahaMucasirogluMVC/   # Ana blog sitesi
│   ├── Admin.../             # Admin paneli
│   └── Cv.../                # CV sitesi
└── Utils/                    # Yardımcı araçlar
    └── DatabaseInstallation/ # Veritabanı kurulum
```

### 🤝 Katkıda Bulunma

Bu dokümantasyon, projenin mevcut durumunu yansıtır. Proje geliştikçe dokümantasyon da güncellenecektir.

### 📞 İletişim

Sorularınız için dokümantasyon dosyalarını inceleyebilir veya proje maintainer'ları ile iletişime geçebilirsiniz.

---

**Not**: Bu dokümantasyon, projenin mevcut hali üzerinden hazırlanmıştır. Gelecek güncellemeler ve yeni özellikler eklendiğinde dokümantasyon da güncellenecektir.