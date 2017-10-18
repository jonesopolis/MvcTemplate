using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnockOut.App.Home.Index;
using Microsoft.AspNetCore.Mvc;

namespace KnockOut.App.Home
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            vm.Name = "David";
            vm.Words = new List<string>{"One", "Two", "Three", "Four", "Five", "Six", "Seven" };
            return View("Index", vm);
        }

        [HttpGet("Help")]
        public IActionResult Help()
        {
            return Ok("Help");
        }
    }
}
