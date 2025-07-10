using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class PropertyBuilderExtension
    {
        #region String

        private static PropertyBuilder<T> StringConfigs<T>(
        this PropertyBuilder<T> propertyBuilder,
        bool isRequired = true,
        int maxLength = 100,
        string columnType = "nvarchar",
        bool unicode = true,
        bool fixedLength = false,
        string? defaultVal = null,
        string? collation = null,
        bool useMax = false)
        {
            if (isRequired)
                propertyBuilder.IsRequired();

            // Uzunluk & sütun tipi tanımı
            string columnTypeDefinition;
            if (useMax)
            {
                columnTypeDefinition = $"{columnType}(max)";
            }
            else
            {
                columnTypeDefinition = $"{columnType}({maxLength})";
                propertyBuilder.HasMaxLength(maxLength);
            }

            propertyBuilder.HasColumnType(columnTypeDefinition)
                           .IsUnicode(unicode);

            if (fixedLength)
                propertyBuilder.IsFixedLength();

            if (!string.IsNullOrWhiteSpace(defaultVal))
                propertyBuilder.HasDefaultValue(defaultVal);

            if (!string.IsNullOrWhiteSpace(collation))
                propertyBuilder.UseCollation(collation);

            return propertyBuilder;
        }

        static public PropertyBuilder<string?> NullableStringConfigs(
            this PropertyBuilder<string?> propertyBuilder,
            int maxLength = 100,
            string columnType = "nvarchar",
            bool unicode = true,
            bool fixedLength = false,
            string? defaultVal = null,
            string? collation = null,
            bool useMax = false)
            => propertyBuilder.StringConfigs(false, maxLength, columnType, unicode, fixedLength, defaultVal, collation, useMax);

        static public PropertyBuilder<string> RequiredStringConfigs(
            this PropertyBuilder<string> propertyBuilder,
            int maxLength = 100,
            string columnType = "nvarchar",
            bool unicode = true,
            bool fixedLength = false,
            string? defaultVal = null,
            string? collation = null,
            bool useMax = false)
            => propertyBuilder.StringConfigs(true, maxLength, columnType, unicode, fixedLength, defaultVal, collation, useMax);

        #endregion

        #region Int
        // Zorunlu tam‑sayı alanlarını tek satırda ayarlar
        private static PropertyBuilder<T> IntConfigs<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true,
            string columnType = "int",      // tinyint, smallint, bigint vb.
            bool isIdentity = false,       // true → Identity (VALUE_GENERATED_ON_ADD)
            int? defaultVal = null)
        {
            if (isIdentity)
                propertyBuilder.ValueGeneratedOnAdd();
            if (isRequired)
                propertyBuilder.IsRequired();

            propertyBuilder.HasColumnType(columnType);

            if (defaultVal is not null)
                propertyBuilder.HasDefaultValue(defaultVal);


            return propertyBuilder;
        }
        public static PropertyBuilder<int> RequiredIntConfigs(
            this PropertyBuilder<int> propertyBuilder,
            string columnType = "int",      // tinyint, smallint, bigint vb.
            bool isIdentity = false,       // true → Identity (VALUE_GENERATED_ON_ADD)
            int? defaultVal = null)
        => propertyBuilder.IntConfigs(true, columnType, isIdentity, defaultVal);


        public static PropertyBuilder<int?> NullableIntConfigs(
            this PropertyBuilder<int?> propertyBuilder,
            string columnType = "int",      // tinyint, smallint, bigint vb.
            bool isIdentity = false,       // true → Identity (VALUE_GENERATED_ON_ADD)
            int? defaultVal = null)
        => propertyBuilder.IntConfigs(false, columnType, isIdentity, defaultVal);
        #endregion

        #region Decimal
        /// <summary>
        /// Zorunlu <c>decimal/numeric</c> sütunu hızlıca yapılandırır.
        /// </summary>
        /// <param name="precision">Toplam basamak (1‑38)</param>
        /// <param name="scale">Ondalık basamak (0‑precision)</param>
        /// <param name="columnType">"decimal" veya "numeric" / "money" / "smallmoney"</param>
        private static PropertyBuilder<T> DecimalConfigs<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true,
            byte precision = 18,
            byte scale = 2,
            string columnType = "decimal",
            decimal? defaultVal = null)
        {
            if (scale > precision)
                throw new ArgumentException("Scale değeri precision değerinden büyük olamaz.", nameof(scale));

            if (columnType.Equals("decimal", StringComparison.OrdinalIgnoreCase) ||
                columnType.Equals("numeric", StringComparison.OrdinalIgnoreCase))
            {
                propertyBuilder.HasColumnType($"{columnType}({precision},{scale})")
                              .HasPrecision(precision, scale);
            }
            else // money, smallmoney ‑ sabit ölçek
            {
                propertyBuilder.HasColumnType(columnType);
            }
            if (isRequired)
                propertyBuilder.IsRequired();

            if (defaultVal is not null)
                propertyBuilder.HasDefaultValue(defaultVal);

            return propertyBuilder;
        }

        static public PropertyBuilder<decimal> RequiredDecimalConfigs(
            this PropertyBuilder<decimal> propertyBuilder,
            byte precision = 18,
            byte scale = 2,
            string columnType = "decimal",
            decimal? defaultVal = null)
            => propertyBuilder.DecimalConfigs(true, precision, scale, columnType, defaultVal);
        static public PropertyBuilder<decimal?> NullableDecimalConfigs(
            this PropertyBuilder<decimal?> propertyBuilder,
            byte precision = 18,
            byte scale = 2,
            string columnType = "decimal",
            decimal? defaultVal = null)
            => propertyBuilder.DecimalConfigs(false, precision, scale, columnType, defaultVal);

        #endregion


        #region Datetime

        /// <summary>
        /// Zorunlu <c>datetime/datetime2</c> sütunu hızlıca yapılandırır.
        /// </summary>
        private static PropertyBuilder<T> DateTimeConfigs<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true,
            string columnType = "smalldatetime", // "datetime", "smalldatetime", "date", "time", "datetimeoffset"
            byte precision = 3,            // 0‑7 (yalnızca datetime2/datetimeoffset)
            bool valueGeneratedOnAdd = false,      // CREATE DATE için
            bool defaultNow = false,        // TRUE → GETDATE() / SYSDATETIME() varsayılanı
            DateTime? defaultVal = null)
        {
            // Column type tanımı
            if (columnType.Equals("datetime2", StringComparison.OrdinalIgnoreCase) ||
                columnType.Equals("datetimeoffset", StringComparison.OrdinalIgnoreCase) ||
                columnType.Equals("time", StringComparison.OrdinalIgnoreCase))
            {
                propertyBuilder.HasColumnType($"{columnType}({precision})");
            }
            else
            {
                propertyBuilder.HasColumnType(columnType); // datetime, date, smalldatetime
            }
            if (isRequired)
                propertyBuilder.IsRequired();

            if (valueGeneratedOnAdd)
                propertyBuilder.ValueGeneratedOnAdd();

            if (defaultNow)
                propertyBuilder.HasDefaultValueSql(columnType.StartsWith("datetimeoffset", StringComparison.OrdinalIgnoreCase)
                                                    ? "SYSDATETIMEOFFSET()"
                                                    : "SYSDATETIME()");
            else if (defaultVal is not null)
                propertyBuilder.HasDefaultValue(defaultVal);

            return propertyBuilder;
        }

        public static PropertyBuilder<DateTime> RequiredDateTimeConfigs(
            this PropertyBuilder<DateTime> propertyBuilder,
            string columnType = "smalldatetime", // "datetime", "smalldatetime", "date", "time", "datetimeoffset"
            byte precision = 3,            // 0‑7 (yalnızca datetime2/datetimeoffset)
            bool valueGeneratedOnAdd = false,      // CREATE DATE için
            bool defaultNow = false,        // TRUE → GETDATE() / SYSDATETIME() varsayılanı
            DateTime? defaultVal = null)
            => propertyBuilder.DateTimeConfigs(true, columnType, precision, valueGeneratedOnAdd, defaultNow, defaultVal);

        public static PropertyBuilder<DateTime?> NullableDateTimeConfigs(
           this PropertyBuilder<DateTime?> propertyBuilder,
           string columnType = "smalldatetime", // "datetime", "smalldatetime", "date", "time", "datetimeoffset"
           byte precision = 3,            // 0‑7 (yalnızca datetime2/datetimeoffset)
           bool valueGeneratedOnAdd = false,      // CREATE DATE için
           bool defaultNow = false,        // TRUE → GETDATE() / SYSDATETIME() varsayılanı
           DateTime? defaultVal = null)
           => propertyBuilder.DateTimeConfigs(false, columnType, precision, valueGeneratedOnAdd, defaultNow, defaultVal);

        #endregion

        #region GUID -----------------------------------------------------------------------------
        /// <summary>
        /// Zorunlu <c>uniqueidentifier</c> (GUID) sütununu yapılandırır.
        /// </summary>
        private static PropertyBuilder<T> GuidConfigs<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true,
            string columnType = "uniqueidentifier",
            bool defaultNewId = false,   // NEWID()
            bool defaultSequential = false,   // NEWSEQUENTIALID()
            bool valueGeneratedOnAdd = false, // EF tarafında ValueGeneratedOnAdd
            Guid? defaultVal = null)
        {
            if (defaultNewId && defaultSequential)
                throw new ArgumentException("defaultNewId ve defaultSequential aynı anda true olamaz.");
            if (isRequired)
                propertyBuilder.IsRequired();

            propertyBuilder.HasColumnType(columnType);

            if (valueGeneratedOnAdd)
                propertyBuilder.ValueGeneratedOnAdd();

            if (defaultNewId)
                propertyBuilder.HasDefaultValueSql("NEWID()");
            else if (defaultSequential)
                propertyBuilder.HasDefaultValueSql("NEWSEQUENTIALID()");
            else if (defaultVal is not null)
                propertyBuilder.HasDefaultValue(defaultVal);

            return propertyBuilder;
        }

        public static PropertyBuilder<Guid> RequiredGuidConfigs(
            this PropertyBuilder<Guid> propertyBuilder,
            string columnType = "uniqueidentifier",
            bool defaultNewId = false,   // NEWID()
            bool defaultSequential = false,   // NEWSEQUENTIALID()
            bool valueGeneratedOnAdd = false, // EF tarafında ValueGeneratedOnAdd
            Guid? defaultVal = null)
            => propertyBuilder.GuidConfigs(true, columnType, defaultNewId, defaultSequential, valueGeneratedOnAdd, defaultVal);

        public static PropertyBuilder<Guid?> NullableGuidConfigs(
            this PropertyBuilder<Guid?> propertyBuilder,
            string columnType = "uniqueidentifier",
            bool defaultNewId = false,   // NEWID()
            bool defaultSequential = false,   // NEWSEQUENTIALID()
            bool valueGeneratedOnAdd = false, // EF tarafında ValueGeneratedOnAdd
            Guid? defaultVal = null)
            => propertyBuilder.GuidConfigs(false, columnType, defaultNewId, defaultSequential, valueGeneratedOnAdd, defaultVal);

        #endregion

        #region BOOL / BIT -----------------------------------------------------------------------
        /// <summary>
        /// Zorunlu <c>bit</c> (bool) sütununu yapılandırır.
        /// </summary>
        private static PropertyBuilder<T> BoolConfigs<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true,
            string columnType = "bit",
            bool? defaultVal = null,
            bool valueGeneratedOnAdd = false)
        {
            if (isRequired)
                propertyBuilder.IsRequired();

            propertyBuilder.HasColumnType(columnType);

            if (valueGeneratedOnAdd)
                propertyBuilder.ValueGeneratedOnAdd();

            if (defaultVal.HasValue)
                propertyBuilder.HasDefaultValue(defaultVal.Value);

            return propertyBuilder;
        }


        static public PropertyBuilder<bool> RequiredBoolConfigs(
            this PropertyBuilder<bool> propertyBuilder,
             bool isRequired = true,
            string columnType = "bit",
            bool? defaultVal = null,
            bool valueGeneratedOnAdd = false)
            => propertyBuilder.BoolConfigs(true, columnType, defaultVal, valueGeneratedOnAdd);
        static public PropertyBuilder<bool?> RequiredBoolConfigs(
           this PropertyBuilder<bool?> propertyBuilder,
            bool isRequired = true,
           string columnType = "bit",
           bool? defaultVal = null,
           bool valueGeneratedOnAdd = false)
           => propertyBuilder.BoolConfigs(false, columnType, defaultVal, valueGeneratedOnAdd);
        #endregion




        public static PropertyBuilder<T> NVarcharMax<T>(
        this PropertyBuilder<T> propertyBuilder,
        bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType("nvarchar(max)");

        /// <summary>varchar(max) – varsayılan olarak NOT NULL.</summary>
        public static PropertyBuilder<T> VarcharMax<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType("varchar(max)");


        /// <summary>ntext – eski tip; geriye dönük gereksinimlerde.</summary>
        public static PropertyBuilder<T> NText<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType("ntext");

        /// <summary>text – eski tip ASCII metin.</summary>
        public static PropertyBuilder<T> Text<T>(
            this PropertyBuilder<T> propertyBuilder,
            bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType("text");

        /// <summary>char(length) veya nchar(length) – sabit uzunluk.</summary>
        public static PropertyBuilder<T> CharFixed<T>(
            this PropertyBuilder<T> propertyBuilder,
            int length,
            bool unicode = false,
            bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType($"{(unicode ? "nchar" : "char")}({length})");

        /// <summary>varchar(length) veya nvarchar(length) – değişken uzunluk.</summary>
        public static PropertyBuilder<T> VarChar<T>(
            this PropertyBuilder<T> propertyBuilder,
            int length,
            bool unicode = false,
            bool isRequired = true)
            => propertyBuilder.IsRequired(isRequired).HasColumnType($"{(unicode ? "nvarchar" : "varchar")}({length})");
    }
}
