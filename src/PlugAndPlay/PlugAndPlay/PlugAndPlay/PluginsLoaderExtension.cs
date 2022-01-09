using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PlugAndPlay
{
    public static class PluginsLoaderExtension
    {
        public static List<Assembly> GetPluginsAssembliesByPath(string path)
        {
            var pluginPath = Path.Combine(Directory.GetCurrentDirectory(), path); // here the approach is very simplified. Plugins should be placed per folder.
                                                                                  // For example: twitter plugin should be in twitter folder
                                                                                  // Plugins=> TwitterPlugin
                                                                                  // now all deps files are under Plugins
            var files = Directory.GetFiles(pluginPath, "*.dll");
            var plugins = new List<Assembly>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadingExtension.LoadAssembly(file);
                plugins.Add(assembly);
            }
            return plugins;
        }
    }
}
