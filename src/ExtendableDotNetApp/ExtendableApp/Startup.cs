using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ExtendableApp.Extensions;
using ExtendableApp.Handlers.DummyEntity;
using ExtendableApp.PipelineBehaviors;
using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SharedEventsAndCommands;

namespace ExtendableApp
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
            // loading plugins into memory 
            var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
            var files = Directory.GetFiles(pluginPath);
            var plugins = new List<Assembly> {typeof(DocumentCreated).Assembly, typeof(Startup).Assembly};
            foreach (var file in files)
            {
                var assembly = PluginsExtension.LoadPlugin(file);
                plugins.Add(assembly);
            }
            
            // registering handlers
            services.AddMediatR(plugins.ToArray());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessRulesBehavior<,>));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExtendableApp", Version = "v1" });
            });
            

            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
                config.UseMediatR();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExtendableApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
