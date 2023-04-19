using System;
using Microsoft.Extensions.Configuration;
using Core.Enums;

namespace Core.AppSettings
{
    public static class ApplicationConfig
    {
        public static int ExplicitTimeout => Convert.ToInt32(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:ExplicitTimeout"));
         public static Browsers BrowserName => Enum.Parse<Browsers>(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:Browser"));
        public static string URL => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("ApplicationConfig:URL"));
    }
}
