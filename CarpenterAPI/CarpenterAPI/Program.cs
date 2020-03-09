using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpenterAPI.Configuration;
using CarpenterAPI.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarpenterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataSeeder = new DataSeeder(AppConfig.ConnectionStringDb); 
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
