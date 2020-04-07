using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCORE_CA_8A.Models;
using NETCORE_CA_8A.DB;
using Microsoft.AspNetCore.Http;

namespace NETCORE_CA_8A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            string hashPassword = Utils.Crypto.Sha256(password);
            HttpContext.Session.SetString("username", username);
            if (new DBTester(new StoreDbContext()).CheckAuthentication(username,hashPassword) == true)
            {
                return RedirectToAction("Gallery", "Home");
            }
            return View();
        }

       
        public IActionResult Gallery()
        {
            return View();
        }

        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
