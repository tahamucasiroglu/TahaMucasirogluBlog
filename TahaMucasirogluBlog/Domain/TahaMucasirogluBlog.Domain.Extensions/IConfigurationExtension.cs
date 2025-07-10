using Microsoft.Extensions.Configuration;

namespace TahaMucasirogluBlog.Domain.Extensions
{
    public static class IConfigurationExtension
    {
        /// <summary>
        /// <see cref="bool"/> <see cref="int"/>  <see cref="decimal"/>  <see cref="double" /> gibi <seealso cref="struct"/> değerlerini desteklemesi gerekir.
        /// </summary>
        public static T GetAppSettingsValue<T>(this IConfiguration configuration, string name, IFormatProvider? provider = null)
            where T : struct, IParsable<T>
        {
            string confValue = configuration[name] ?? throw new Exception($"{name}  değeri AppSettings.json içinde bulunamadı");
            try
            {
                return T.Parse(confValue, provider);
            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsValue)} methodda hata var. Hata = {e.Message}");
            }
        }

        /// <summary>
        /// <see cref="string"/> için özel olan method. String için <seealso cref="ArgumentNullException"/> değerine bakar
        /// </summary>
        public static string GetAppSettingsValue(this IConfiguration configuration, string name, IFormatProvider? provider = null)
        {
            string confValue = configuration[name] ?? throw new Exception($"{name}  değeri AppSettings.json içinde bulunamadı");
            try
            {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(confValue);
                return confValue;
            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsValue)} methodda hata var. Hata = {e.Message}");
            }
        }

        /// <summary>
        /// Liste için
        /// </summary>
        public static IEnumerable<T> GetAppSettingsList<T>(this IConfiguration configuration, string name, IFormatProvider? provider = null)
            where T : struct, IParsable<T>
        {
            try
            {
                return configuration
                    .GetSection(name)
                    .GetChildren()
                    .Select(x => x.Value == null ? default : T.Parse(x.Value, provider));

            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsList)} methodda hata var. Hata = {e.Message}");
            }
        }

        /// <summary>
        /// Liste için
        /// </summary>
        public static IEnumerable<string> GetAppSettingsList(this IConfiguration configuration, string name, IFormatProvider? provider = null)
        {
            try
            {
                return configuration
                    .GetSection(name)
                    .GetChildren()
                    .Select(x => x.Value ?? "");

            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsList)} methodda hata var. Hata = {e.Message}");
            }
        }


        /// <summary>
        /// Dictionary için
        /// </summary>
        public static Dictionary<string, T> GetAppSettingsDict<T>(this IConfiguration configuration, string name, IFormatProvider? provider = null)
            where T : struct, IParsable<T>
        {
            try
            {
                Dictionary<string, T> res = new Dictionary<string, T>();
                configuration
                    .GetSection(name)
                    .GetChildren()
                    .ToList()
                    .ForEach(x => res.Add(x.Key, x.Value == null ? default : T.Parse(x.Value, provider)));

                return res;

            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsDict)} methodda hata var. Hata = {e.Message}");
            }
        }

        /// <summary>
        /// Dictionary için
        /// </summary>
        public static Dictionary<string, string> GetAppSettingsDict(this IConfiguration configuration, string name, IFormatProvider? provider = null)
        {
            try
            {
                Dictionary<string, string> res = new Dictionary<string, string>();
                configuration
                    .GetSection(name)
                    .GetChildren()
                    .ToList()
                    .ForEach(x => res.Add(x.Key, x.Value ?? ""));
                return res;
            }
            catch (Exception e)
            {

                throw new Exception($"{nameof(IConfigurationExtension)} içindeki {nameof(GetAppSettingsDict)} methodda hata var. Hata = {e.Message}");
            }
        }



    }
}
