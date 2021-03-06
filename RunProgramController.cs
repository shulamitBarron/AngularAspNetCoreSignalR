﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularAspNetCoreSignalR {
    [Route ("api/[controller]")]
    public class RunProgramController : Controller {
        public static int num=7;
        // GET: api/<controller>
        [HttpGet]
        public FileResult Get () {
            // var fileName = "DeleteDoubleFiles.exe";
            var fileName = "publish.rar";
            var filepath = Path.Combine (Environment.CurrentDirectory, "Release", "publish.rar");
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File (fileBytes, "application/x-msdownload", fileName);
        }

        // GET api/<controller>/5
        [HttpGet ("{id}")]
        public int Get (int id) {
            if(id==1)
               num++;
            return num;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/<controller>/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/<controller>/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}