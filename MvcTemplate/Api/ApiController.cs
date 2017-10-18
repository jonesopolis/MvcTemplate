using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnockOut.Api
{
    [Route("api")]
    public class ApiController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string>{"hello", "Hi", "Howdy"});
        }
    }
}