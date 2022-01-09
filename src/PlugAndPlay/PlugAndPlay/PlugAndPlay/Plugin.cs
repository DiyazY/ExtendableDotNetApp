using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlugAndPlay.Shared;

namespace PlugAndPlay
{
    public static class PluginExtension
    {
        public static readonly IDictionary<string, string> Executors = new Dictionary<string, string>(); // possible memory leak.

        public static void AddPluginDefinitions(this IServiceCollection services, params Type[] scanMarkers)
        {
            var assemblies = PluginsLoaderExtension.GetPluginsAssembliesByPath("Plugins");
            var plugins = new List<IPlugin>();

            foreach (var assembly in assemblies)
            {
                plugins.AddRange(
                    assembly.ExportedTypes
                        .Where(x => typeof(IPlugin).IsAssignableFrom(x) && !x.IsAbstract)
                        .Select(Activator.CreateInstance).Cast<IPlugin>()
                    );
            }

            foreach (var plugin in plugins)
            {
                plugin.DefineServices(services);
                var executors = plugin.GetExecutors();
                foreach (var exec in executors)
                {
                    Executors.Add(exec.type, exec.name);
                }
            }

            if (plugins.Any())
            {
                services.AddSingleton(plugins as IReadOnlyCollection<IPlugin>);
            }
        }

        public static void UsePluginDefinitions(this IApplicationBuilder app)
        {
            var plugins = app.ApplicationServices.GetService<IReadOnlyCollection<IPlugin>>();
            foreach (var plugin in plugins)
            {
                plugin.DefinePlugin(app);
            }
        }

        public static object ExecuteIt(string type, string jsonPayload)
        {
            var t = Type.GetType(type);
            var instance = Activator.CreateInstance(t) as IExecutor;
            return instance?.Execute(jsonPayload);
        }
    }
}
