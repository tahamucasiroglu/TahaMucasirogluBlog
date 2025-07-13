# TahaMucasirogluBlog.Domain.Extensions - Extension Metodları Projesi Dokümantasyonu

## Proje Amacı

Bu proje, .NET tiplerini genişleten extension metodlarını içerir. Extension metodlar, var olan tiplere yeni fonksiyonaliteler eklemek için kullanılır ve kod tekrarını önler.

## Proje Yapısı

```
TahaMucasirogluBlog.Domain.Extensions/
├── DateTimeExtension.cs
├── GuidExtension.cs
├── HashingExtensions.cs
├── IConfigurationExtension.cs
├── IEnumerableExtension.cs
├── IQueryableExtension.cs
├── IntegerExtension.cs
├── JsonExtension.cs
├── ObjectExtension.cs
├── PropertyBuilderExtension.cs
└── StringExtension.cs
```

## Extension Metodları Detayları

### DateTimeExtension.cs

DateTime tipi için yardımcı metodlar.

```csharp
public static class DateTimeExtension
{
    // Unix timestamp'e çevirme
    public static long ToUnixTimestamp(this DateTime dateTime)
    {
        return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
    }
    
    // Türkçe tarih formatı
    public static string ToTurkishDateString(this DateTime dateTime)
    {
        return dateTime.ToString("dd MMMM yyyy", new CultureInfo("tr-TR"));
    }
    
    // Göreli zaman (2 saat önce, 3 gün önce vb.)
    public static string ToRelativeTime(this DateTime dateTime)
    {
        var timeSpan = DateTime.Now - dateTime;
        
        if (timeSpan.TotalMinutes < 1)
            return "Az önce";
        if (timeSpan.TotalMinutes < 60)
            return $"{(int)timeSpan.TotalMinutes} dakika önce";
        if (timeSpan.TotalHours < 24)
            return $"{(int)timeSpan.TotalHours} saat önce";
        if (timeSpan.TotalDays < 30)
            return $"{(int)timeSpan.TotalDays} gün önce";
        
        return dateTime.ToTurkishDateString();
    }
}
```

### GuidExtension.cs

Guid tipi için yardımcı metodlar.

```csharp
public static class GuidExtension
{
    // Guid'in boş olup olmadığını kontrol etme
    public static bool IsEmpty(this Guid guid)
    {
        return guid == Guid.Empty;
    }
    
    // Guid'in dolu olup olmadığını kontrol etme
    public static bool IsNotEmpty(this Guid guid)
    {
        return guid != Guid.Empty;
    }
    
    // Short Guid oluşturma (URL-friendly)
    public static string ToShortString(this Guid guid)
    {
        var bytes = guid.ToByteArray();
        var base64 = Convert.ToBase64String(bytes)
            .Replace("+", "-")
            .Replace("/", "_")
            .TrimEnd('=');
        return base64;
    }
}
```

### HashingExtensions.cs

String hashleme için extension metodlar.

```csharp
public static class HashingExtensions
{
    // SHA256 hash
    public static string ToSHA256(this string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
    
    // MD5 hash
    public static string ToMD5(this string input)
    {
        using (var md5 = MD5.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
    
    // BCrypt hash
    public static string ToBCrypt(this string input)
    {
        return BCrypt.Net.BCrypt.HashPassword(input);
    }
    
    // BCrypt verify
    public static bool VerifyBCrypt(this string input, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(input, hash);
    }
}
```

### IConfigurationExtension.cs

IConfiguration için yardımcı metodlar.

```csharp
public static class IConfigurationExtension
{
    // Güvenli değer okuma
    public static T GetValueSafe<T>(this IConfiguration configuration, string key, T defaultValue = default)
    {
        var value = configuration[key];
        if (string.IsNullOrEmpty(value))
            return defaultValue;
        
        try
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        catch
        {
            return defaultValue;
        }
    }
    
    // Connection string helper
    public static string GetConnectionStringSafe(this IConfiguration configuration, string name)
    {
        var connectionString = configuration.GetConnectionString(name);
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException($"Connection string '{name}' not found.");
        
        return connectionString;
    }
}
```

### IEnumerableExtension.cs

IEnumerable koleksiyonları için yardımcı metodlar.

```csharp
public static class IEnumerableExtension
{
    // Boş kontrolü
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
    {
        return source == null || !source.Any();
    }
    
    // Sayfalama
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page, int pageSize)
    {
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }
    
    // Batch işleme
    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
    {
        var batch = new List<T>(batchSize);
        foreach (var item in source)
        {
            batch.Add(item);
            if (batch.Count == batchSize)
            {
                yield return batch;
                batch = new List<T>(batchSize);
            }
        }
        
        if (batch.Any())
            yield return batch;
    }
    
    // Distinct by property
    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        var seen = new HashSet<TKey>();
        foreach (var item in source)
        {
            if (seen.Add(keySelector(item)))
                yield return item;
        }
    }
}
```

### IQueryableExtension.cs

IQueryable için yardımcı metodlar (Entity Framework sorguları için).

```csharp
public static class IQueryableExtension
{
    // Dinamik sıralama
    public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName, bool descending = false)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, propertyName);
        var lambda = Expression.Lambda(property, parameter);
        
        var methodName = descending ? "OrderByDescending" : "OrderBy";
        var resultExpression = Expression.Call(
            typeof(Queryable),
            methodName,
            new[] { typeof(T), property.Type },
            source.Expression,
            Expression.Quote(lambda)
        );
        
        return source.Provider.CreateQuery<T>(resultExpression);
    }
    
    // Soft delete filtresi
    public static IQueryable<T> WhereNotDeleted<T>(this IQueryable<T> source) where T : IEntity
    {
        return source.Where(x => !x.IsDeleted);
    }
    
    // Include if
    public static IQueryable<T> IncludeIf<T, TProperty>(
        this IQueryable<T> source,
        bool condition,
        Expression<Func<T, TProperty>> navigationPropertyPath) where T : class
    {
        return condition ? source.Include(navigationPropertyPath) : source;
    }
}
```

### IntegerExtension.cs

Integer tipi için yardımcı metodlar.

```csharp
public static class IntegerExtension
{
    // Sayı basamaklarını ayırma (1000 -> 1.000)
    public static string ToFormattedString(this int number)
    {
        return number.ToString("N0", new CultureInfo("tr-TR"));
    }
    
    // Byte dönüşümü
    public static string ToByteSize(this long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        double size = bytes;
        
        while (size >= 1024 && order < sizes.Length - 1)
        {
            order++;
            size = size / 1024;
        }
        
        return $"{size:0.##} {sizes[order]}";
    }
    
    // Range kontrolü
    public static bool IsInRange(this int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}
```

### JsonExtension.cs

JSON serileştirme/deserileştirme için yardımcı metodlar.

```csharp
public static class JsonExtension
{
    // Object to JSON
    public static string ToJson<T>(this T obj, bool indented = false)
    {
        var options = new JsonSerializerSettings
        {
            Formatting = indented ? Formatting.Indented : Formatting.None,
            NullValueHandling = NullValueHandling.Ignore
        };
        
        return JsonConvert.SerializeObject(obj, options);
    }
    
    // JSON to Object
    public static T FromJson<T>(this string json)
    {
        if (string.IsNullOrEmpty(json))
            return default(T);
            
        return JsonConvert.DeserializeObject<T>(json);
    }
    
    // Safe deserialization
    public static bool TryFromJson<T>(this string json, out T result)
    {
        result = default(T);
        
        try
        {
            result = json.FromJson<T>();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
```

### ObjectExtension.cs

Object tipi için genel yardımcı metodlar.

```csharp
public static class ObjectExtension
{
    // Deep copy
    public static T DeepCopy<T>(this T source)
    {
        var json = source.ToJson();
        return json.FromJson<T>();
    }
    
    // Null kontrolü
    public static bool IsNull(this object obj)
    {
        return obj == null;
    }
    
    // Type kontrolü
    public static bool Is<T>(this object obj)
    {
        return obj is T;
    }
    
    // Safe casting
    public static T As<T>(this object obj) where T : class
    {
        return obj as T;
    }
}
```

### PropertyBuilderExtension.cs

Entity Framework Property Builder için extension metodlar.

```csharp
public static class PropertyBuilderExtension
{
    // Decimal precision
    public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> propertyBuilder, int precision, int scale)
    {
        return propertyBuilder.HasColumnType($"decimal({precision},{scale})");
    }
    
    // Default value
    public static PropertyBuilder<T> HasDefaultValue<T>(this PropertyBuilder<T> propertyBuilder, T defaultValue)
    {
        return propertyBuilder.HasDefaultValue(defaultValue);
    }
    
    // Required with max length
    public static PropertyBuilder<string> IsRequiredWithMaxLength(this PropertyBuilder<string> propertyBuilder, int maxLength)
    {
        return propertyBuilder.IsRequired().HasMaxLength(maxLength);
    }
}
```

### StringExtension.cs

String tipi için yardımcı metodlar.

```csharp
public static class StringExtension
{
    // Slug oluşturma
    public static string ToSlug(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        
        // Türkçe karakterleri değiştir
        text = text.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u")
                  .Replace("ş", "s").Replace("ö", "o").Replace("ç", "c")
                  .Replace("İ", "i").Replace("Ğ", "g").Replace("Ü", "u")
                  .Replace("Ş", "s").Replace("Ö", "o").Replace("Ç", "c");
        
        // Alfanumerik olmayan karakterleri tire ile değiştir
        text = Regex.Replace(text, @"[^a-z0-9\s-]", "", RegexOptions.IgnoreCase);
        text = Regex.Replace(text, @"\s+", "-");
        text = Regex.Replace(text, @"-+", "-");
        
        return text.ToLower().Trim('-');
    }
    
    // Truncate
    public static string Truncate(this string text, int maxLength, string suffix = "...")
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;
        
        return text.Substring(0, maxLength - suffix.Length) + suffix;
    }
    
    // Email validation
    public static bool IsValidEmail(this string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;
        
        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }
}
```

## Kullanım Örnekleri

```csharp
// DateTime extensions
var date = DateTime.Now;
var relativeTime = date.ToRelativeTime(); // "2 saat önce"
var turkishDate = date.ToTurkishDateString(); // "15 Ocak 2024"

// String extensions
var title = "Bu Bir Blog Yazısı Başlığı!";
var slug = title.ToSlug(); // "bu-bir-blog-yazisi-basligi"
var summary = content.Truncate(100); // İlk 100 karakter + "..."

// IEnumerable extensions
var items = GetItems();
var paged = items.Paginate(page: 2, pageSize: 10);
var batches = items.Batch(batchSize: 50);

// JSON extensions
var user = new User { Name = "Taha", Email = "taha@example.com" };
var json = user.ToJson(indented: true);
var deserializedUser = json.FromJson<User>();
```

## Best Practices

1. **Null Safety**: Extension metodlarda null kontrolü yapın
2. **Performance**: Hesaplama yoğun işlemleri optimize edin
3. **Naming**: Method isimleri açık ve anlaşılır olmalı
4. **Documentation**: Her metod için XML documentation ekleyin
5. **Testing**: Extension metodlar için unit test yazın
6. **Immutability**: Mümkünse input parametresini değiştirmeyin