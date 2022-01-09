using System;
namespace PlugAndPlay.Shared
{
    public interface IExecutor
    {
        object Execute(string payload);
    }
}
