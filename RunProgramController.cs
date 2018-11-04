using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularAspNetCoreSignalR
{
    [Route("api/[controller]")]
    public class RunProgramController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            var process = Process.Start(Path.Combine(Environment.CurrentDirectory, "Release", "DeleteDoubleFiles.exe")); //Process.Start("/Release/DeleteDoubleFiles.exe");
            if (process == null) // failed to start../
            {
                return "Fail";
            }
            else // Started, wait for it to finish
            {
                //process.WaitForExit();
                //process.Start();
                return "Ok";
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
