    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpenterAPI.Configuration
{
    public class ConfigurationHelper
    {
        public static string GetEnvByString(string variableName, bool required, string defaultValue)
        {
            var value = Environment.GetEnvironmentVariable(variableName);
            if (value == null)
            {
                if (required)
                    throw new NullReferenceException("No environment variable was found with that name");
                return defaultValue;

            }
            return value;
        }
    }
}
