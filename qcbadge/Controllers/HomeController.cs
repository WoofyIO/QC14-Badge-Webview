using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace qcbadge.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string s, string id, int refresh)
        {
            Helpers.Sql sql = new Helpers.Sql();
            ViewData["refresh"] = refresh;

            if ((String.Compare(Startup.scode, s, true) == 0))
            {
                ViewData["Message"] = "";
                ViewData["0"] = 0;
                ViewData["1"] = 0;
                ViewData["38"] = 0;

                bool[] imglist = new bool[50];

                if (String.IsNullOrEmpty(id))
                {
                    imglist = sql.selectGlobalView();

                    for (int i = 0; i < 50; i++)
                    {
                        ViewData[i.ToString()] = imglist[i];
                    }
                }
                else
                {
                    int badgeid = Convert.ToInt32(id);
                    badgeid = badgeid - 1;
                    imglist = sql.selectIndervidualView(badgeid);

                    for (int i = 0; i < 50; i++)
                    {
                        ViewData[i.ToString()] = imglist[i];
                    }

                }

                return View();
            }
            else { return StatusCode(401); }

        }

        public IActionResult List(string s, string id, int refresh)
        {
            Helpers.Sql sql = new Helpers.Sql();
            ViewData["refresh"] = refresh;

            if ((String.Compare(Startup.scode, s, true) == 0))
            {
                ViewData["Message"] = "";
                ViewData["0"] = 0;
                ViewData["1"] = 0;
                ViewData["38"] = 0;

                bool[] imglist = new bool[50];

                if (String.IsNullOrEmpty(id))
                {
                    imglist = sql.selectGlobalView();

                    for (int i = 0; i < 50; i++)
                    {
                        ViewData[i.ToString()] = imglist[i];
                    }
                }
                else
                {
                    int badgeid = Convert.ToInt32(id);
                    badgeid = badgeid - 1;
                    imglist = sql.selectIndervidualView(badgeid);

                    for (int i = 0; i < 50; i++)
                    {
                        ViewData[i.ToString()] = imglist[i];
                    }

                }

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
