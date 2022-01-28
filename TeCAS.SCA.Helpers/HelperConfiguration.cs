using Microsoft.Extensions.Configuration;

namespace TeCAS.SCA.Helpers
{
    public class HelperConfiguration
    {
       public static AppConfiguration GetAppConfiguration(string configurationFile = "App.json")
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile(configurationFile, optional: false)
                .Build();

            var Result = Configuration.Get<AppConfiguration>();
            return Result;
        }
    }
}
