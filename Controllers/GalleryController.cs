﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

       // [Route("/galleryRoute")]
        public IActionResult Gallery(int itemCount=0,string keyword="")
        {
            ViewBag.ItemCount = itemCount;
            int? uid = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = uid;

            string uname = HttpContext.Session.GetString("Username");
            ViewBag.Username = uname;

            ViewBag.products = GetAllProducts(keyword);
            if(ViewBag.products.Count==0)
            {
                ViewBag.search = "not found";
              
            }
            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");
                ViewBag.Username = HttpContext.Session.GetString("Username");
            }
            
            ViewBag.ItemCount = HttpContext.Session.GetInt32("cartItemCount");
            if(keyword != "")
            {
                ViewBag.serchKeyword = keyword;
            }
            return View();
        }

        public List<Product> GetAllProducts(string keyword)
        {
            if (keyword == "")
            {
                return _dbcontext.Products.ToList();
            }

            if (keyword == null)
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