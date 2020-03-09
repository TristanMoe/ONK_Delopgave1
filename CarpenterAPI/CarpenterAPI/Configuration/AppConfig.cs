using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Configuration
{
    public static class AppConfig
    {
        public static string GetServiceIP => ConfigurationHelper.GetEnvByString("CARPENTER-MONGODB-IP", false, "34.91.119.227");
        public static string GetServicePort => ConfigurationHelper.GetEnvByString("CARPENTER-MONGODB-PORT", false, "8080");
        public static string ConnectionStringDb => "mongodb://" + GetServiceIP + ":" + GetServicePort;
    }
}
