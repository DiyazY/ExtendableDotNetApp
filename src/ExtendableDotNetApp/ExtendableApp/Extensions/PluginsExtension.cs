using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.DependencyModel.Resolution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;


namespace ExtendableApp.Extensions
{
    public class PluginsExtension
    {
        private static ICompilationAssemblyResolver _assemblyResolver;
        private static DependencyContext _dependencyContext;
        private static AssemblyLoadContext _loadContext;
        
        public static Assembly LoadPlugin(string path)
        {
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(path);
            _dependencyContext = DependencyContext.Load(assembly);

            _assemblyResolver = new CompositeCompilationAssemblyResolver(new ICompilationAssemblyResolver[]
            {
                  new AppBaseCompilationAssemblyResolver(Path.GetDirectoryName(path)),
                  new ReferenceAssemblyPathResolver(),
                  new PackageCompilationAssemblyResolver()

             });

            _loadContext = AssemblyLoadContext.GetLoadContext(assembly);
            
            if (_loadContext != null) 
                _loadContext.Resolving += OnResolving;

            return assembly;
        }

        private static Assembly OnResolving(AssemblyLoadContext context, AssemblyName name)
        {
            bool NamesMatch(RuntimeLibrary runtime)
            {
                return string.Equals(runtime.Name, name.Name, StringComparison.OrdinalIgnoreCase);
            }

            RuntimeLibrary library = _dependencyContext?.RuntimeLibraries.FirstOrDefault(NamesMatch);
            if (library != null)
            {
                var wrapper = new CompilationLibrary(
                    library.Type,
                    library.Name,
                    library.Version,
                    library.Hash,
                    library.RuntimeAssemblyGroups.SelectMany(g => g.AssetPaths),
                    library.Dependencies,
                    library.Serviceable);

                var assemblies = new List<string>();
                _assemblyResolver.TryResolveAssemblyPaths(wrapper, assemblies);
                if (assemblies.Count > 0)
                {
                    return _loadContext.LoadFromAssemblyPath(assemblies[0]);
                }
            }

            return null;
        }
    }
}