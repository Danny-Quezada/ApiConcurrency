using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConcurrencyApp.Common
{
    public class AppSettings
    {
        public static string ApiUrl { get => ConfigurationManager.AppSettings.Get("ApiUrl"); }
        public static string Token { get => ConfigurationManager.AppSettings.Get("Token"); }
        public static string Units { get => ConfigurationManager.AppSettings.Get("Units"); }
        public static string Image { get => ConfigurationManager.AppSettings.Get("ImagesUrl"); }
        public static string Cities { get => ConfigurationManager.AppSettings.Get("JsonLocation"); }
    }
}
