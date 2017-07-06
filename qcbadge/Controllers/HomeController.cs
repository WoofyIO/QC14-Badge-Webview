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

        public IActionResult Update(string advertData)
        {

            //// Flags; this sets the device to use limited discoverable
            //// mode (advertises for 30 seconds at a time) instead of general
            //// discoverable mode (advertises indefinitely)
            //2,   // length of this data
            //GAP_ADTYPE_FLAGS, // 0x01
            //GAP_ADTYPE_FLAGS_BREDR_NOT_SUPPORTED, // 0x04 

            //// Appearance: This is a #badgelife header.
            //3,    // Length of this data
            //GAP_ADTYPE_APPEARANCE, // Data type: "Appearance" // 0x19
            //0xDC, // DC
            //0x19, // 19 #badgelife

            //// Queercon data: ID, current icon, etc
            //15, // length of this data including the data type byte
            //GAP_ADTYPE_MANUFACTURER_SPECIFIC, // manufacturer specific adv data type // 0xff
            //0xD3, // Company ID - Fixed (queercon)
            //0x04, // Company ID - Fixed (queercon)
            //0x00, // Badge ID MSB
            //0x00, // Badge ID LSB
            //0x00, // Current icon ID
            //0x00, // RESERVED
            //0x00, // icon 32..39
            //0x00, // icon 24..31
            //0x00, // icon 16..23
            //0x00, // icon  8..15
            //0x00, // icon  0.. 7
            //0x00, // CHECK

            //9,
            //GAP_ADTYPE_LOCAL_NAME_SHORT, // 0x08
            //0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,

            //     Jakes take on the header:
            //     0x0201040319DC190FFFD304 < -Fixed header
            //     [AAAA] < -Badge ID 0 - 289 In Dec / 0000 - 0121 in Hex
            //     [BB] < -Current Icon
            //     [CC] < -RESERVED(incase jonathan wants more than 40 icons ?)
            //     [DDDDDDDDDD] < -icon bit array 39...........0
            //     [EE] < -Checksum
            //     0908[0000000000000000] < -End + Crypto

            if (String.IsNullOrEmpty(advertData))
            {

                return StatusCode(400);

            }
            else
            {
                return StatusCode(200);
            }

        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
