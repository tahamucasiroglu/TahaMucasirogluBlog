
* [TahaMucasirogluBlog.Client.TahaMucasirogluMVC](https://tahamucasiroglu.com.tr/)

* [TahaMucasirogluBlog.Client.Cv.TahaMucasirogluMVC](https://cv.tahamucasiroglu.com.tr/)

* [TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC](https://p2pmessage.tahamucasiroglu.com.tr/)

* [TahaMucasirogluBlog.Client.Admin.TahaMucasirogluMVC](https://admin.tahamucasiroglu.com.tr/)







# TahaMucasirogluBlog

[🇹🇷 Türkçe](#turkish) | [🇬🇧 English](#english)

---

## Turkish

### Proje Hakkında

![TahaMucasirogluArchitecture](./Documentation/Src/TahaMucasirogluArchitecture.png)

TahaMucasirogluBlog, .NET 8.0 ve Clean Architecture prensipleriyle geliştirilmiş modern bir blog ve CV platformudur. Entity Framework Core, AutoMapper, FluentValidation ve JWT Authentication teknolojileri kullanılarak oluşturulmuştur.

### Mimari

Proje Clean Architecture yaklaşımıyla 4 ana katmandan oluşur:
- **Domain**: Entity'ler, DTO'lar, Model'ler, Sabitler
- **Application**: Manager'lar, Mapping, Validation
- **Infrastructure**: Repository Pattern, Database Context
- **Presentation**: API Controller'ları ve Client uygulamaları

### Dokümantasyon

Detaylı dokümantasyon için [Documentation](./Documentation/) klasörünü inceleyiniz:

- [Mimari Genel Bakış](./Documentation/Architecture_TR.md)
- [Domain Katmanı](./Documentation/)
  - [Entity'ler](./Documentation/Entities_TR.md)
  - [DTO'lar](./Documentation/DTOs_TR.md)
  - [Model'ler](./Documentation/Models_TR.md)
  - [Sabitler](./Documentation/Constants_TR.md)
  - [Extension'lar](./Documentation/Extensions_TR.md)
  - [Return Types](./Documentation/Return_TR.md)
- [Application Katmanı](./Documentation/)
  - [Manager'lar](./Documentation/Managers_TR.md)
  - [Mapping](./Documentation/Mapper_TR.md)
  - [Validation](./Documentation/Validation_TR.md)
- [Infrastructure Katmanı](./Documentation/)
  - [Repository Pattern](./Documentation/Repository_TR.md)
- [Service Katmanı](./Documentation/)
  - [Database Service](./Documentation/DatabaseService_TR.md)
  - [CV Service](./Documentation/CvService_TR.md)
- [Presentation Katmanı](./Documentation/)
  - [API](./Documentation/API_TR.md)
  - [Client'lar](./Documentation/Clients_TR.md)
  - [Utils](./Documentation/Utils_TR.md)

### Teknolojiler

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- JWT Authentication
- Clean Architecture

---

## English

### About the Project

![TahaMucasirogluArchitecture](./Documentation/Src/TahaMucasirogluArchitecture.png)

TahaMucasirogluBlog is a modern blog and CV platform developed with .NET 8.0 and Clean Architecture principles. Built using Entity Framework Core, AutoMapper, FluentValidation, and JWT Authentication technologies.

### Architecture

The project follows Clean Architecture approach with 4 main layers:
- **Domain**: Entities, DTOs, Models, Constants
- **Application**: Managers, Mapping, Validation
- **Infrastructure**: Repository Pattern, Database Context
- **Presentation**: API Controllers and Client applications

### Documentation

For detailed documentation, please check the [Documentation](./Documentation/) folder:

- [Architecture Overview](./Documentation/Architecture_EN.md)
- Domain Layer
  - [Entities](./Documentation/Entities_TR.md)
  - [DTOs](./Documentation/DTOs_TR.md)
  - [Models](./Documentation/Models_TR.md)
  - [Constants](./Documentation/Constants_TR.md)
  - [Extensions](./Documentation/Extensions_TR.md)
  - [Return Types](./Documentation/Return_TR.md)
- Application Layer
  - [Managers](./Documentation/Managers_TR.md)
  - [Mapping](./Documentation/Mapper_TR.md)
  - [Validation](./Documentation/Validation_TR.md)
- Infrastructure Layer
  - [Repository Pattern](./Documentation/Repository_TR.md)
- Service Layer
  - [Database Service](./Documentation/DatabaseService_TR.md)
  - [CV Service](./Documentation/CvService_TR.md)
- Presentation Layer
  - [API](./Documentation/API_TR.md)
  - [Clients](./Documentation/Clients_TR.md)
  - [Utils](./Documentation/Utils_TR.md)

### Technologies

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- JWT Authentication
- Clean Architecture