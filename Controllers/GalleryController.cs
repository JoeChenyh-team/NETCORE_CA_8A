using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NETCORE_CA_8A.DB;
using NETCORE_CA_8A.Models;


// This controller is for the Gallery. 

namespace NETCORE_CA_8A.Controllers
{
    public class GalleryController : Controller
    {
        protected StoreDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;

        public GalleryController(StoreDbContext dbcontext, ILogger<HomeController> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        public IActionResult Gallery(string username,string keyword="")
        {
            ViewData["username"] = username;
            ViewBag.products = GetAllProducts(keyword);
            if(ViewBag.products.Count==0)
            {
                ViewBag.search = "not found";
            }
            return View();
        }

        public List<Product> GetAllProducts(string keyword)
        {
            if (keyword == "")
            {
                return _dbcontext.Products.ToList();
            }

           

            return _dbcontext.Products.Where(p =>
                    p.productName.ToLower().Contains(keyword.ToLower()) ||
                    p.description.ToLower().Contains(keyword.ToLower()))
                    .ToList();
        }
    }
}