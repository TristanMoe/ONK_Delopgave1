using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CraftsmanApp.Data;
using CraftsmanApp.Services;
using CraftsmanApp.Configuration;
using System.Text.Json;

namespace CraftsmanApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddRazorPages();
            var host = AppConfig.GetServiceIP;
            var port = AppConfig.GetServicePort;
            var baseAdd = "http://" + host + ":" + port + "/";

            services.AddHttpClient<CraftsmanClient>();
            services.AddHttpClient<ToolboxClient>();
            services.AddHttpClient<ToolClient>();

            services.AddDbContext<CraftsmanAppContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "testDatabase"));
        }//UseSqlServer(Configuration.GetConnectionString("CraftsmanAppContext"))

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
