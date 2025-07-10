using System.Text.RegularExpressions;

namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class StringExtension
    {
        static public bool IsPhoneNumber(this string? str)
            => !string.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^(\+90|0)?5\d{9}$");

        static public bool IsIdentityNumber(this string? str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length != 11)
            {
                return false;
            }

            int[] digits = str.Select(c => (int)char.GetNumericValue(c)).ToArray();

            int sumOddDigits = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int sumEvenDigits = digits[1] + digits[3] + digits[5] + digits[7];

            int tenthDigit = (sumOddDigits * 7 - sumEvenDigits) % 10;
            if (tenthDigit < 0) tenthDigit += 10;

            int eleventhDigit = (sumOddDigits + sumEvenDigits + digits[9]) % 10;

            return digits[9] == tenthDigit && digits[10] == eleventhDigit;
        }

        static public bool IsValidTaxNumber(this string? taxNumber)
        {
            if (string.IsNullOrWhiteSpace(taxNumber) || taxNumber.Length != 10)
            {
                return false;
            }
            int[] digits = taxNumber.Select(c => (int)char.GetNumericValue(c)).ToArray();
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = digits[i];
                int subtracted = digit + 10 - ((i + 1) % 10);
                sum += subtracted % 10;
            }
            int checkDigit = (sum % 10 == 0) ? 0 : (10 - (sum % 10));
            return checkDigit == digits[9];
        }


        static public bool IsOnlyLetter(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : str.All(char.IsLetter);

        static public bool IsOnlyPunctuation(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : str.All(char.IsPunctuation);

        static public bool IsOnlyDigits(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : Regex.IsMatch(str, @"^\d+$");

        static public bool IsLetterOrDigit(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : str.All(char.IsLetterOrDigit);

        static public bool IsLetterOrPunctuation(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : str.All(e => char.IsPunctuation(e) && char.IsLetter(e));

        static public bool IsLetterOrDigitOrPunctuation(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : str.All(e => char.IsPunctuation(e) && char.IsLetterOrDigit(e));

        static public bool IsValidUtf8(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : Regex.IsMatch(str, @"^[\p{L}\p{N}]+$");

        static public bool IsSha512Hash(this string? str, bool nullReturn = false) => string.IsNullOrWhiteSpace(str) ? nullReturn : !string.IsNullOrEmpty(str) && str.Length == 128 && Regex.IsMatch(str, @"^[a-fA-F0-9]+$");

        public static string TurkishToEnglish(this string src)
        {
            if (string.IsNullOrWhiteSpace(src)) return "";

            // string.Create: yalnızca hedef string’i oluşturur, ara buffer yok
            return string.Create(src.Length, src, (span, s) =>
            {
                for (int i = 0; i < s.Length; i++)
                {
                    // C# 8 switch ifadesiyle tek satırda eşleme
                    span[i] = s[i] switch
                    {
                        'ç' => 'c',
                        'Ç' => 'C',
                        'ğ' => 'g',
                        'Ğ' => 'G',
                        'ı' => 'i',
                        'İ' => 'I',
                        'ş' => 's',
                        'Ş' => 'S',
                        'ö' => 'o',
                        'Ö' => 'O',
                        'ü' => 'u',
                        'Ü' => 'U',
                        char x => x
                    };
                }
            });
        }




        /// <summary>
        /// HomeController gelen string değerini Home olarak verir. <see cref="nameof"/> ile kullanım için nameof(HomeController).SetControllerName() gibi
        /// </summary>
        public static string SetControllerName(this string controllerName)
        {
            return controllerName.Replace("Controller", "");
        }

        /// <summary>
        /// HomeController gelen string değerini Home olarak verir. <see cref="nameof"/> ile kullanım için nameof(HomeController).SetControllerNameToUrlName() gibi
        /// </summary>
        public static string SetControllerNameToUrlName(this string controllerName)
        {
            return controllerName.Replace("Controller", "");
        }


        /// <summary>
        /// HomeController gelen string değerini HomeFilterButton olarak verir. <see cref="nameof"/> ile kullanım için nameof(HomeController).SetControllerNameToFilterButtonName() gibi
        /// </summary>
        public static string SetControllerNameToFilterButtonName(this string controllerName)
        {
            return controllerName.Replace("Controller", "FilterButton");
        }

        /// <summary>
        /// HomeController gelen string değerini HomeTable olarak verir. <see cref="nameof"/> ile kullanım için nameof(HomeController).SetControllerNameToTableName() gibi
        /// </summary>
        public static string SetControllerNameToTableName(this string controllerName)
        {
            return controllerName.Replace("Controller", "Table");
        }


        /// <summary>
        /// HomeController gelen string değerini HomePageSizeSelect olarak verir. <see cref="nameof"/> ile kullanım için nameof(HomeController).SetControllerNameToPageSizeSelectName() gibi
        /// </summary>
        public static string SetControllerNameToPageSizeSelectName(this string controllerName)
        {
            return controllerName.Replace("Controller", "PageSizeSelect");
        }



        /// <summary>
        /// UrunSearchModalView gelen yazıyı vw_UrunSearchModal yapar.
        /// </summary>
        public static string SetViewName(this string viewName)
        {
            return $"vw_{viewName.Replace("View", "")}";
        }
        /// <summary>
        /// UrunSearchModalView gelen yazıyı vw_UrunSearchModal yapar.
        /// </summary>
        public static string SetViewName(this object viewObj)
        {
            if (viewObj == null) return "";
            return SetViewName(viewObj.GetType().Name);
        }


        /// <summary>
        /// NTNTakipMainDBContext gelen yazıyı NTNTakipMainDB yapar.
        /// </summary>
        public static string SetContextName(this string viewName)
        {
            return viewName.Replace("Context", "");
        }
        /// <summary>
        /// NTNTakipMainDBContext gelen yazıyı NTNTakipMainDB yapar.
        /// </summary>
        public static string SetContextName(this object viewObj)
        {
            if (viewObj == null) return "";
            return SetContextName(viewObj.GetType().Name);
        }




        private static readonly char[] TurkishVowels = new[]
        {
            'a','e','ı','i','o','ö','u','ü',
            'A','E','I','İ','O','Ö','U','Ü'
        };

        private static readonly char[] FrontVowels = new[] { 'e', 'i', 'ö', 'ü', 'E', 'İ', 'Ö', 'Ü' };
        private static readonly char[] BackVowels = new[] { 'a', 'ı', 'o', 'u', 'A', 'I', 'O', 'U' };

        /// <summary>
        /// Türkçe sözcükler için çoğul ekini otomatik ekleyen yardımcı metotlar.
        /// Türkçe bir kelimeyi uygun "-ler" veya "-lar" ekini ekleyerek çoğullaştırır.
        /// Kelime zaten "ler" veya "lar" ile bitiyorsa değiştirmez.
        /// </summary>
        /// <param name="word">Tekil veya zaten çoğul formdaki kelime.</param>
        /// <returns>Çoğul formdaki kelime.</returns>
        public static string ToPluralTurkish(this string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return word;

            // Zaten "lar" veya "ler" ile bitiyorsa dokunma
            var lower = word.ToLowerInvariant();
            if (lower.EndsWith("lar") || lower.EndsWith("ler"))
                return word;

            // Kelimenin son ünlüsünü bul
            char lastVowel = '\0';
            for (int i = word.Length - 1; i >= 0; i--)
            {
                var c = word[i];
                if (TurkishVowels.Contains(c))
                {
                    lastVowel = c;
                    break;
                }
            }

            // Önce ünlü uyumuna göre ek seç: front vs back
            string suffix = FrontVowels.Contains(lastVowel)
                ? "ler"
                : "lar";

            return word + suffix;
        }



        public static string? ToLowerFirstChar(this string? input)
        {
            if (string.IsNullOrEmpty(input) || char.IsLower(input[0]))
                return input;
            string res = char.ToLower(input[0]).ToString();
            res = res.TurkishToEnglish();
            return res + input.Substring(1);
        }




    }
}
