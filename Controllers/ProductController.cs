/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE_CA_8A.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}*/

using System;
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
    public class ProductController : Controller
    {
        protected StoreDbContext _dbcontext;
        private readonly ILogger<ProductController> _logger;

        public ProductController(StoreDbContext dbcontext, ILogger<ProductController> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }
        public IActionResult View2(string newid)
        {
            ViewData["newid"] = newid;
            ViewBag.Product = GetAllProducts(newid);
            ViewBag.Recommendation = GetAllRecommend(newid);
            ViewBag.Review = GetAllReview(newid);


            string uname = HttpContext.Session.GetString("Username");
            ViewBag.Username = uname;

            if (ViewBag.Product.Count == 0)
            {
                ViewBag.search = "not found";
            }
            return View();
        }

        public List<Product> GetAllProducts(string newid)
        {
            if (newid == "")
            {
                return _dbcontext.Products.ToList();
            }

            if (newid == null)
            {
                return _dbcontext.Products.ToList();
            }



            return _dbcontext.Products.Where(p =>
                    p.Id.ToLower() == newid.ToLower()).ToList();
        }

        public List<Product> GetAllRecommend(string newid)
        {
            

            string CategoryId = _dbcontext.Products.Where(p => p.Id == newid).Select(Category => Category.CategoryId).Single();

            List<Product> Recommendations = _dbcontext.Products.Where(c => c.CategoryId == CategoryId && c.Id != newid).ToList();

            return Recommendations;

        }

        public List<Review> GetAllReview(string newid)
        {
            if (newid == "")
            {
                return _dbcontext.Review.ToList();
            }

            if (newid == null)
            {
                return _dbcontext.Review.ToList();
            }



            return _dbcontext.Review.Where(p =>
                    p.ProductId.ToLower() == newid.ToLower()).ToList();
        }
    }
}
   