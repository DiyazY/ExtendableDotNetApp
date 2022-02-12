using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlugAndPlay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluginController : ControllerBase
    {
        // GET: api/Plugin
        [HttpGet]
        public IDictionary<string,string> Get()
        {
            return PluginExtension.Executors;
        }

        // POST: api/Plugin
        [HttpPost("execute")]
        public void Post([FromBody] ExecuteCommand command)
        {
            PluginExtension.ExecuteIt(command.Type, command.Payload);
        }

        public class ExecuteCommand
        {
            public string Type { get; set; }
            public string Payload { get; set; }
        }
    }
}
