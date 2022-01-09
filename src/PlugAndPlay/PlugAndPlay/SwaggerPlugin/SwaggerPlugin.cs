using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PlugAndPlay.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace SwaggerPlugin
{
    public class SwaggerPlugin : IPlugin
    {

        public void DefineServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "p&p", Description = "TODO: add some description" }));
        }

        public void DefinePlugin(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"API v1");
            });
        }


        public IEnumerable<(string type, string name)> GetExecutors()
        {
            return new List<(string, string)>(); // could be better here. swagger doesn't have any executors
        }
    }
}
