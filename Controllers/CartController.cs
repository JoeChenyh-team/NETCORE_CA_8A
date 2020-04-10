using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using NETCORE_CA_8A.DB;
using NETCORE_CA_8A.Models;

namespace NETCORE_CA_8A.Controllers
{
    public class CartController : Controller
    {
        protected StoreDbContext db;
        private readonly ILogger<CartController> _logger;
        

        public CartController(StoreDbContext dbcontext, ILogger<CartController> logger)
        {
            db = dbcontext;
            _logger = logger;
        }
        public ActionResult AddtoCart(string productId,string fromProdDetail="")
        {
            ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");
            ViewBag.Username = (string)HttpContext.Session.GetString("Username");
            ViewBag.ItemCount = AddItemToCart(productId, 1);
            //return PartialView("_cartLogo");
            if(fromProdDetail == "true")
            {
                return RedirectToRoute(new { controller = "Product", action = "View2", itemCount = ViewBag.ItemCount });
            }
            return RedirectToRoute(new { controller = "Gallery", action = "Gallery", itemCount = ViewBag.ItemCount });
        }

        public ActionResult Cart()
        {
            ViewBag.ItemCount = GetItemCount();
            ViewBag.CartItems = GetAllCartItems();
            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AddItemToCart(string productId, int quantity)
        {
            // int userId = HttpContext.Session.GetInt32("UserId");
            int userId = 1;
            using (IDbContextTransaction dbTransaction = db.Database.BeginTransaction())
            {
                Cart cart = db.Cart.FirstOrDefault(x => x.CustomerId == userId && x.IsCheckOut == 0);
                try
                {
                    if (cart == null)
                    {
                        cart = new Cart(userId);
                        db.Cart.Add(cart);
                        db.SaveChanges();
                    }

                    // Product product = db.Products.FirstOrDefault(x => x.Id == productId);
                    Product product = db.Products
                             .Where(x => x.Id == productId)
                             .FirstOrDefault();

                    if (product == null)
                    {
                        throw new Exception("Product not exists");
                    }

                    CartItem cartItem = db.CartItem.FirstOrDefault(x => x.CartId == cart.Id && x.ProductId == productId);

                    if (cartItem == null)
                    {
                        cartItem = new CartItem(cart.Id, productId);
                        db.CartItem.Add(cartItem);
                       db.SaveChanges();
                    }
                    else
                    {
                        cartItem.Quantity += quantity;
                    }

                    if (cartItem.Quantity == 0)
                    {
                        db.CartItem.Remove(cartItem);
                        db.SaveChanges();
                    }

                    cart.Quantity += quantity;
               /*     cart.Value += quantity * product.unitPrice;  temporarily hide*/

                    db.SaveChanges();
                    dbTransaction.Commit();
                    return cart.Quantity;
                }
                catch (Exception e)
                {
                    dbTransaction.Rollback();
                    throw new Exception(e.Message);
                }
            }
        }


        public List<CartItem> GetAllCartItems()
        {
            // int userId = HttpContext.Session.GetInt32("UserId");
            int userId = 1;
            var query = db.Cart.Where(cart => cart.CustomerId == userId && cart.IsCheckOut == 0).Select(cart => cart.Id).FirstOrDefault();
            return GetCartItems(query);
        }

        public int GetItemCount()
        {
            //int userId = (int)HttpContext.Session["UserId"];
            int userId = 1;
            Cart cart = db.Cart.FirstOrDefault(x => x.CustomerId == userId && x.IsCheckOut == 0);

            if (cart == null)
            {
                cart = new Cart(userId);
                db.Cart.Add(cart);
                db.SaveChanges();
                return 0;
            }

            return cart.Quantity;
        }
        public List<CartItem> GetCartItems(int cartId)
        {
            var query = db.CartItem.Where(cartItem => cartItem.CartId == cartId)
                    .Join(db.Products, item => item.ProductId, product => product.Id,
                        (item, product) => new
                        {
                            Id = item.Id,
                            CartId = item.CartId,
                            ProductId = product.Id,
                            Quantity = item.Quantity,
                            Product = product,
                            CheckoutTime = db.Cart.Where(cart => cart.Id == cartId).Select(cart => cart.CheckoutTime).FirstOrDefault(),
                            ActivationCodes = db.Purchased.Where(p => p.CartItemId == item.Id).Select(p => p.ActivationCode).ToList()
                        }).ToList();

            return query.Select(x => new CartItem
            {
                Id = x.Id,
                CartId = x.CartId,
                ProductId = (x.Id).ToString(),
                Quantity = x.Quantity,
                Product = x.Product,
                CheckoutTime = x.CheckoutTime,
                ActivationCodes = x.ActivationCodes
            }).ToList();
        }
    }
}