using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Configuration
{
    public static class AppConfig
    {
        public static string GetServiceIP => ConfigurationHelper.GetEnvByString("CARPENTER-MONGODB-IP", false, "localhost");
        public static string GetServicePort => ConfigurationHelper.GetEnvByString("CARPENTER-MONGODB-PORT", false, "27017");
        public static string ConnectionStringDb => "mongodb://" + GetServiceIP + ":" + GetServicePort;
    }
}
