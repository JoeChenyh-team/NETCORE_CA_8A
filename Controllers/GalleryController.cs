using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE_CA_8A.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Gallery(string username)
        {
            ViewData["username"] = username;
            return View();
        }
    }
}