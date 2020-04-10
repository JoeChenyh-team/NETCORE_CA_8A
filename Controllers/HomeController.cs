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

//This controller is for the Home Page (for Login) 

namespace NETCORE_CA_8A.Controllers
{
    public class HomeController : Controller
    {
        protected StoreDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(StoreDbContext dbcontext,ILogger<HomeController> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            string hashPassword = Utils.Crypto.Sha256(password);
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Username = HttpContext.Session.GetString("Username");

            if (CheckAuthentication(username, hashPassword))
                //return RedirectToAction("Gallery","Home");
                return RedirectToRoute(new { controller = "Gallery", action = "Gallery", username = username });

            else
            {
                TempData["loginErrorMessage"] = "Invalid Username and password!";
                return RedirectToAction("Index", "Home");
            }
               
        }

        public bool CheckAuthentication(string name, string password)
        {
            var cust = _dbcontext.Customers.Where(x => x.Name == name)
                     .FirstOrDefault();
            if (cust == null || cust.Password != password)
            {
                return false;
            }
            HttpContext.Session.SetString("Username", cust.Name);
            HttpContext.Session.SetInt32("UserId", cust.Id);
            return true;

        }

        
        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
