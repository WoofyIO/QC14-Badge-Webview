using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace qcbadge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string s)
        {
            if ((String.Compare(Startup.scode, s, true) == 0))
            {
                ViewData["Message"] = "";
                ViewData["0"] = 1;
                ViewData["1"] = 1;
                ViewData["38"] = 1;

                return View();
            }
            else { return StatusCode(401); }


        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
