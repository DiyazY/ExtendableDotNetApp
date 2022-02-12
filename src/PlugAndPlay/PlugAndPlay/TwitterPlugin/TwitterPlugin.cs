using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlugAndPlay.Shared;

namespace TwitterPlugin
{
    public class TwitterPlugin : IPlugin
    {
        public void DefinePlugin(IApplicationBuilder app)
        {
            // add what you want to inject if u need it
        }

        public void DefineServices(IServiceCollection services)
        {
            // use what u want
        }

        public IEnumerable<(string type, string name)> GetExecutors()
        {
            Type t = typeof(TwitExecutor);
            yield return (t.AssemblyQualifiedName, "twit it!!!");
        }
    }
}
