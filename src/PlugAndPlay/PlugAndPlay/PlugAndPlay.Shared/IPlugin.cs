using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PlugAndPlay.Shared
{
    public interface IPlugin
    {
        void DefineServices(IServiceCollection services);
        void DefinePlugin(IApplicationBuilder app);
        IEnumerable<(string type, string name)> GetExecutors(); // this might be implemented better, especially type field. it should be forced to use AssemblyQualifiedName
    }
}
