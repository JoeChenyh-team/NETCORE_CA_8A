using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NETCORE_CA_8A.DB;
using NETCORE_CA_8A.Models;
using Newtonsoft.Json;

namespace NETCORE_CA_8A.Controllers
{
    public class Cart1Controller : Controller
    {
        protected StoreDbContext _dbcontext1;
        private readonly ILogger<Cart1Controller> _logger;
        List<Product> pro;
        Product product = new Product();


        public Cart1Controller(StoreDbContext dbcontext, ILogger<Cart1Controller> logger)
        {
            _dbcontext1 = dbcontext;
            _logger = logger;
        }
        // GET: Cart
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.unitPrice * item.Quantity);
            return View();
        }
        
        public IActionResult AddtoCart(string id)
        {
            if (HttpContext.Session.GetString("cart") == null || HttpContext.Session.GetString("cart") != "true")
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = FindProductById(id), Quantity = 1 });
                
                ViewBag.cart = cart;
                HttpContext.Session.SetString("cart", "true");
                //SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = ViewBag.cart;
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = FindProductById(id), Quantity = 1 });
                }
                ViewBag.cart = cart;
            }
            return View();
            //return RedirectToAction("Index");
        }

        /*
        public IActionResult AddtoCart(string id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = FindProductById(id), Quantity = 1 });
                //SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = FindProductById(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        */
       
        public List<Product> FindAll()
        {
            return _dbcontext1.Products.ToList();

        }

        public Product FindProductById(string id)
        {
            /* return _dbcontext1.Products
                 .Where(x => x.Id == id)
                 .FirstOrDefault();*/
            //return _dbcontext1.Products.Single(p => p.Id.Equals(id));
            // product= _dbcontext1.Products
            // .Where(p => p.Id == id).FirstOrDefault();
            var productlist = new List<Product>();
            Product a = _dbcontext1.Products
                .FromSqlRaw(@"SELECT * FROM Products WHERE Id = {0}", "1")
                .FirstOrDefault();

            return a;

        }

        private int isExist(string id)
        {
            //List<Item> cart = ViewBag.cart;
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        /*private int isExist(string id)
        {
            //List<Item> cart = (List<Item>)Session["cart"];
            List<Item> cart = ViewBag.cart;
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }
        */
        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}