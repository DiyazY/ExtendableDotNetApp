using System;
using PlugAndPlay.Shared;

namespace TwitterPlugin
{
    public class TwitExecutor: IExecutor
    {
        public object Execute(string payload)
        {
            Console.WriteLine($"twited: {payload}"); // do whatever u want
            return this;
        }
    }
}
