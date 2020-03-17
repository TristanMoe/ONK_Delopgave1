using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsmanApp.Configuration
{
    public class AppConfig
    {
        public static string GetServiceIP => ConfigurationHelper.GetEnvByString("CRAFTSMAN-API-IP", false, "localhost");
        public static string GetServicePort => ConfigurationHelper.GetEnvByString("CRAFTSMAN-API-PORT", false, "5000");
    }
}
