using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftsmanApp.Configuration
{
    public class AppConfig
    {
        public static string GetServiceIP => ConfigurationHelper.GetEnvByString("CARPENTER-API-IP", false, "carpenter-api-balancer");
        public static string GetServicePort => ConfigurationHelper.GetEnvByString("CARPENTER-API-PORT", false, "8080");
    }
}
