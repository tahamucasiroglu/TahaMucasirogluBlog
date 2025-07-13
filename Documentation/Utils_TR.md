# TahaMucasirogluBlog.Utils - Utility Projeleri Dokümantasyonu

## Proje Amacı

Utils katmanı, yardımcı araçları ve utility uygulamalarını içerir. Database migration, seed data, data import/export, maintenance tasks gibi one-time veya scheduled operations için kullanılır.

## Utils Projeleri

### TahaMucasirogluBlog.Utils.DatabaseInstallation

Veritabanı kurulum, migration ve seed data işlemlerini yöneten console application.

## Proje Yapısı

```
TahaMucasirogluBlog.Utils.DatabaseInstallation/
├── Program.cs
└── TahaMucasirogluBlog.Utils.DatabaseInstallation.csproj
```

## DatabaseInstallation Projesi

### Program.cs

Veritabanı kurulum ve migration işlemlerini yöneten ana program.

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Utils.DatabaseInstallation;

class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("TahaMucasirogluBlog Database Installation Utility");
        Console.WriteLine("================================================");
        
        try
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<TahaMucasirogluBlogContext>();
                
                logger.LogInformation("Starting database installation...");
                
                // Parse command line arguments
                var options = ParseArguments(args);
                
                switch (options.Operation.ToLower())
                {
                    case "install":
                        await InstallDatabaseAsync(context, logger, options);
                        break;
                    case "migrate":
                        await MigrateDatabaseAsync(context, logger);
                        break;
                    case "seed":
                        await SeedDataAsync(context, logger, options);
                        break;
                    case "reset":
                        await ResetDatabaseAsync(context, logger, options);
                        break;
                    case "backup":
                        await BackupDatabaseAsync(context, logger, options);
                        break;
                    case "restore":
                        await RestoreDatabaseAsync(context, logger, options);
                        break;
                    default:
                        ShowUsage();
                        break;
                }
                
                logger.LogInformation("Database operation completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var configuration = context.Configuration;
                
                // Add Entity Framework
                services.AddDbContext<TahaMucasirogluBlogContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                
                // Add logging
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                    builder.SetMinimumLevel(LogLevel.Information);
                });
            });
    
    private static async Task InstallDatabaseAsync(
        TahaMucasirogluBlogContext context, 
        ILogger logger, 
        DatabaseOptions options)
    {
        logger.LogInformation("Installing database...");
        
        // Create database if not exists
        var created = await context.Database.EnsureCreatedAsync();
        
        if (created)
        {
            logger.LogInformation("Database created successfully.");
        }
        else
        {
            logger.LogInformation("Database already exists.");
        }
        
        // Apply migrations
        await context.Database.MigrateAsync();
        logger.LogInformation("Migrations applied successfully.");
        
        // Seed initial data if requested
        if (options.SeedData)
        {
            await SeedDataAsync(context, logger, options);
        }
        
        logger.LogInformation("Database installation completed.");
    }
    
    private static async Task MigrateDatabaseAsync(
        TahaMucasirogluBlogContext context, 
        ILogger logger)
    {
        logger.LogInformation("Applying database migrations...");
        
        var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
        
        if (pendingMigrations.Any())
        {
            logger.LogInformation($"Found {pendingMigrations.Count()} pending migrations:");
            foreach (var migration in pendingMigrations)
            {
                logger.LogInformation($"  - {migration}");
            }
            
            await context.Database.MigrateAsync();
            logger.LogInformation("Migrations applied successfully.");
        }
        else
        {
            logger.LogInformation("No pending migrations found.");
        }
    }
    
    private static async Task SeedDataAsync(
        TahaMucasirogluBlogContext context, 
        ILogger logger, 
        DatabaseOptions options)
    {
        logger.LogInformation("Seeding database with initial data...");
        
        // Seed Users
        await SeedUsersAsync(context, logger);
        
        // Seed Categories
        await SeedCategoriesAsync(context, logger);
        
        // Seed Tags
        await SeedTagsAsync(context, logger);
        
        // Seed Experience Types
        await SeedExperienceTypesAsync(context, logger);
        
        // Seed Skills
        await SeedSkillsAsync(context, logger);
        
        // Seed Social Links
        await SeedSocialLinksAsync(context, logger);
        
        // Seed Info
        await SeedInfoAsync(context, logger);
        
        // Seed sample blog posts if in development mode
        if (options.Environment == "Development")
        {
            await SeedSampleBlogPostsAsync(context, logger);
        }
        
        await context.SaveChangesAsync();
        logger.LogInformation("Data seeding completed.");
    }
    
    private static async Task SeedUsersAsync(TahaMucasirogluBlogContext context, ILogger logger)
    {
        if (await context.Users.AnyAsync())
        {
            logger.LogInformation("Users already exist, skipping user seeding.");
            return;
        }
        
        logger.LogInformation("Seeding users...");
        
        var adminUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Taha",
            LastName = "Mucasiroğlu",
            Email = "admin@tahamucasiroglu.com",
            PasswordHash = "$2a$11$Yfz/Qn9kQGlRzI8DGl0Ive7wqZXK7KyVnTx8zP5p5VwJxE8GW1b8u", // "Admin123!"
            IsActive = true,
            EmailConfirmed = true,
            Role = "Admin",
            Bio = "Yazılım geliştirici, teknoloji tutkunu ve blog yazarı.",
            CreatedDate = DateTime.UtcNow
        };
        
        context.Users.Add(adminUser);
        logger.LogInformation("Admin user created.");
    }
    
    private static async Task SeedCategoriesAsync(TahaMucasirogluBlogContext context, ILogger logger)
    {
        if (await context.Categories.AnyAsync())
        {
            logger.LogInformation("Categories already exist, skipping category seeding.");
            return;
        }
        
        logger.LogInformation("Seeding categories...");
        
        var categories = new[]
        {
            new Category { Id = Guid.NewGuid(), Name = "Teknoloji", Slug = "teknoloji", Description = "Teknoloji haberleri ve yorumları", Color = "#007bff", Order = 1 },
            new Category { Id = Guid.NewGuid(), Name = "Yazılım Geliştirme", Slug = "yazilim-gelistirme", Description = "Yazılım geliştirme teknikleri ve best practices", Color = "#28a745", Order = 2 },
            new Category { Id = Guid.NewGuid(), Name = ".NET", Slug = "dotnet", Description = ".NET teknolojileri ve C# programlama", Color = "#6f42c1", Order = 3 },
            new Category { Id = Guid.NewGuid(), Name = "Web Development", Slug = "web-development", Description = "Web geliştirme teknolojileri", Color = "#fd7e14", Order = 4 },
            new Category { Id = Guid.NewGuid(), Name = "Veritabanı", Slug = "veritabani", Description = "Veritabanı tasarımı ve optimizasyonu", Color = "#20c997", Order = 5 },
            new Category { Id = Guid.NewGuid(), Name = "Kişisel", Slug = "kisisel", Description = "Kişisel deneyimler ve düşünceler", Color = "#e83e8c", Order = 6 }
        };
        
        context.Categories.AddRange(categories);
        logger.LogInformation($"Added {categories.Length} categories.");
    }
    
    private static async Task SeedTagsAsync(TahaMucasirogluBlogContext context, ILogger logger)
    {
        if (await context.Tags.AnyAsync())
        {
            logger.LogInformation("Tags already exist, skipping tag seeding.");
            return;
        }
        
        logger.LogInformation("Seeding tags...");
        
        var tags = new[]
        {
            new Tag { Id = Guid.NewGuid(), Name = "C#", Slug = "csharp" },
            new Tag { Id = Guid.NewGuid(), Name = "ASP.NET Core", Slug = "aspnet-core" },
            new Tag { Id = Guid.NewGuid(), Name = "Entity Framework", Slug = "entity-framework" },
            new Tag { Id = Guid.NewGuid(), Name = "JavaScript", Slug = "javascript" },
            new Tag { Id = Guid.NewGuid(), Name = "TypeScript", Slug = "typescript" },
            new Tag { Id = Guid.NewGuid(), Name = "React", Slug = "react" },
            new Tag { Id = Guid.NewGuid(), Name = "SQL Server", Slug = "sql-server" },
            new Tag { Id = Guid.NewGuid(), Name = "Clean Architecture", Slug = "clean-architecture" },
            new Tag { Id = Guid.NewGuid(), Name = "Design Patterns", Slug = "design-patterns" },
            new Tag { Id = Guid.NewGuid(), Name = "REST API", Slug = "rest-api" }
        };
        
        context.Tags.AddRange(tags);
        logger.LogInformation($"Added {tags.Length} tags.");
    }
    
    private static async Task SeedExperienceTypesAsync(TahaMucasirogluBlogContext context, ILogger logger)
    {
        if (await context.ExperienceTypes.AnyAsync())
        {
            logger.LogInformation("Experience types already exist, skipping experience type seeding.");
            return;
        }
        
        logger.LogInformation("Seeding experience types...");
        
        var experienceTypes = new[]
        {
            new ExperienceType { Id = Guid.NewGuid(), Name = "İş Deneyimi", Description = "Profesyonel iş deneyimleri" },
            new ExperienceType { Id = Guid.NewGuid(), Name = "Eğitim", Description = "Eğitim geçmişi" },
            new ExperienceType { Id = Guid.NewGuid(), Name = "Sertifika", Description = "Profesyonel sertifikalar" },
            new ExperienceType { Id = Guid.NewGuid(), Name = "Proje", Description = "Kişisel ve profesyonel projeler" },
            new ExperienceType { Id = Guid.NewGuid(), Name = "Gönüllülük", Description = "Gönüllü çalışmalar" }
        };
        
        context.ExperienceTypes.AddRange(experienceTypes);
        logger.LogInformation($"Added {experienceTypes.Length} experience types.");
    }
    
    private static async Task ResetDatabaseAsync(
        TahaMucasirogluBlogContext context, 
        ILogger logger, 
        DatabaseOptions options)
    {
        logger.LogWarning("Resetting database - ALL DATA WILL BE LOST!");
        
        if (!options.Force)
        {
            Console.Write("Are you sure you want to reset the database? (y/N): ");
            var confirmation = Console.ReadLine();
            
            if (confirmation?.ToLower() != "y")
            {
                logger.LogInformation("Database reset cancelled.");
                return;
            }
        }
        
        logger.LogInformation("Deleting database...");
        await context.Database.EnsureDeletedAsync();
        
        logger.LogInformation("Recreating database...");
        await context.Database.EnsureCreatedAsync();
        
        logger.LogInformation("Applying migrations...");
        await context.Database.MigrateAsync();
        
        if (options.SeedData)
        {
            await SeedDataAsync(context, logger, options);
        }
        
        logger.LogInformation("Database reset completed.");
    }
    
    private static DatabaseOptions ParseArguments(string[] args)
    {
        var options = new DatabaseOptions();
        
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLower())
            {
                case "--operation":
                case "-o":
                    if (i + 1 < args.Length)
                        options.Operation = args[++i];
                    break;
                case "--seed":
                case "-s":
                    options.SeedData = true;
                    break;
                case "--force":
                case "-f":
                    options.Force = true;
                    break;
                case "--environment":
                case "-e":
                    if (i + 1 < args.Length)
                        options.Environment = args[++i];
                    break;
                case "--backup-path":
                case "-bp":
                    if (i + 1 < args.Length)
                        options.BackupPath = args[++i];
                    break;
            }
        }
        
        return options;
    }
    
    private static void ShowUsage()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  DatabaseInstallation --operation <operation> [options]");
        Console.WriteLine("");
        Console.WriteLine("Operations:");
        Console.WriteLine("  install   - Create database and apply migrations");
        Console.WriteLine("  migrate   - Apply pending migrations");
        Console.WriteLine("  seed      - Seed database with initial data");
        Console.WriteLine("  reset     - Reset database (WARNING: Deletes all data)");
        Console.WriteLine("  backup    - Backup database");
        Console.WriteLine("  restore   - Restore database from backup");
        Console.WriteLine("");
        Console.WriteLine("Options:");
        Console.WriteLine("  --seed, -s           - Seed initial data after install/reset");
        Console.WriteLine("  --force, -f          - Force operation without confirmation");
        Console.WriteLine("  --environment, -e    - Environment (Development/Production)");
        Console.WriteLine("  --backup-path, -bp   - Path for backup/restore operations");
        Console.WriteLine("");
        Console.WriteLine("Examples:");
        Console.WriteLine("  DatabaseInstallation -o install -s");
        Console.WriteLine("  DatabaseInstallation -o migrate");
        Console.WriteLine("  DatabaseInstallation -o reset -s -f");
        Console.WriteLine("  DatabaseInstallation -o backup -bp C:\\Backups\\");
    }
}

public class DatabaseOptions
{
    public string Operation { get; set; } = "install";
    public bool SeedData { get; set; } = false;
    public bool Force { get; set; } = false;
    public string Environment { get; set; } = "Production";
    public string BackupPath { get; set; } = "";
}
```

### Project File (.csproj)

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Logging" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="8.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\Infrastructure\TahaMucasirogluBlog.Infrastructure.Repository\TahaMucasirogluBlog.Infrastructure.Repository.csproj" />
    <ProjectReference Include="..\..\Domain\TahaMucasirogluBlog.Domain.Entities\TahaMucasirogluBlog.Domain.Entities.csproj" />
  </ItemGroup>

  <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
    <None Update="appsettings.Development.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

</Project>
```

### appsettings.json

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TahaMucasirogluBlog;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

## Kullanım Örnekleri

### 1. İlk Kurulum

```bash
# Veritabanını oluştur, migration'ları uygula ve initial data'yı seed et
DatabaseInstallation.exe --operation install --seed

# Kısa versiyon
DatabaseInstallation.exe -o install -s
```

### 2. Migration Uygulama

```bash
# Sadece pending migration'ları uygula
DatabaseInstallation.exe --operation migrate

# Kısa versiyon
DatabaseInstallation.exe -o migrate
```

### 3. Data Seeding

```bash
# Sadece initial data'yı seed et
DatabaseInstallation.exe --operation seed

# Development environment için seed et
DatabaseInstallation.exe -o seed -e Development
```

### 4. Database Reset

```bash
# Veritabanını resetle ve yeniden seed et (onay ister)
DatabaseInstallation.exe --operation reset --seed

# Force reset (onay istemez)
DatabaseInstallation.exe -o reset -s -f
```

### 5. Backup ve Restore

```bash
# Backup oluştur
DatabaseInstallation.exe -o backup -bp "C:\Backups\"

# Backup'tan restore et
DatabaseInstallation.exe -o restore -bp "C:\Backups\backup_20240101.bak"
```

## Batch Scripts

### install-db.bat

```batch
@echo off
echo TahaMucasirogluBlog Database Installation
echo ======================================

cd /d "%~dp0"

echo Installing database with initial data...
DatabaseInstallation.exe -o install -s

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Database installation completed successfully!
) else (
    echo.
    echo Database installation failed!
    pause
    exit /b %ERRORLEVEL%
)

pause
```

### migrate-db.bat

```batch
@echo off
echo TahaMucasirogluBlog Database Migration
echo ====================================

cd /d "%~dp0"

echo Applying database migrations...
DatabaseInstallation.exe -o migrate

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Database migration completed successfully!
) else (
    echo.
    echo Database migration failed!
    pause
    exit /b %ERRORLEVEL%
)

pause
```

## Docker Support

### Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/TahaMucasirogluBlog.Utils.DatabaseInstallation.csproj", "Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/"]
RUN dotnet restore "Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/TahaMucasirogluBlog.Utils.DatabaseInstallation.csproj"
COPY . .
WORKDIR "/src/Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation"
RUN dotnet build "TahaMucasirogluBlog.Utils.DatabaseInstallation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TahaMucasirogluBlog.Utils.DatabaseInstallation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TahaMucasirogluBlog.Utils.DatabaseInstallation.dll"]
```

### docker-compose.yml

```yaml
version: '3.8'

services:
  database-installer:
    build:
      context: .
      dockerfile: Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/Dockerfile
    environment:
      - ConnectionStrings__DefaultConnection=Server=sqlserver;Database=TahaMucasirogluBlog;User Id=sa;Password=YourPassword123!;TrustServerCertificate=true;
    command: ["--operation", "install", "--seed"]
    depends_on:
      - sqlserver
    networks:
      - blog-network

  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourPassword123!
    ports:
      - "1433:1433"
    networks:
      - blog-network

networks:
  blog-network:
    driver: bridge
```

## CI/CD Integration

### GitHub Actions Workflow

```yaml
name: Database Migration

on:
  push:
    branches: [ main ]
    paths:
      - 'Infrastructure/TahaMucasirogluBlog.Infrastructure.Repository/Migrations/**'

jobs:
  migrate:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    
    - name: Restore dependencies
      run: dotnet restore Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/
    
    - name: Build
      run: dotnet build Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/ --no-restore
    
    - name: Run migrations
      run: |
        cd Utils/TahaMucasirogluBlog.Utils.DatabaseInstallation/
        dotnet run -- --operation migrate
      env:
        ConnectionStrings__DefaultConnection: ${{ secrets.DATABASE_CONNECTION_STRING }}
```

## Best Practices

1. **Backup Before Operations**: Kritik operasyonlar öncesi backup alın
2. **Environment Awareness**: Farklı environment'lar için farklı configuration'lar kullanın
3. **Idempotent Operations**: Aynı operasyonu birden fazla çalıştırabilme
4. **Logging**: Tüm operasyonları detaylı loglayın
5. **Error Handling**: Hata durumlarını graceful handle edin
6. **Confirmation**: Destructive operasyonlar için confirmation isteyin
7. **Rollback Strategy**: Failed migration'lar için rollback planı hazırlayın