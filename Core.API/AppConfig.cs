using Core.AppSettings;
using Microsoft.Extensions.Configuration;

namespace Core.API
{
    public class APIConfig
    {
        public int Timeout => Convert.ToInt32(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("APIConfig:Timeout"));
        public string BaseUrl => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("APIConfig:BaseUrl"));
        public string ApiPath => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("APIConfig:ApiPath"));
        public string ProjectName => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("APIConfig:ProjectName"));
        public string Uuid => new string(TestConfigurationManager.GetConfigurationRoot().GetValue<string>("APIConfig:Uuid"));
    }
}
