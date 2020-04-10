using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCORE_CA_8A.Models;

namespace NETCORE_CA_8A.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}
        /*
        public ActionResult AddtoCart(string id)
        {
            Product product = new Product(); 
            
            ProductModel productModel = new ProductModel();
            if (HttpContext.Session.GetString("cart") == null) 
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                //HttpContext.Session.Set("cart", cart);
                //HttpContext.Session.SetComplexData("cart", cart);
                //HttpContext.Session.SetObject("cart", cart);
                //HttpContext.Session["cart"] = cart;
                //HttpContext.Session.Set<Item>("cart", cart);
                ViewBag.cart = cart;
            }
            else
            {
                // List<Item> cart = (List<Item>)Session["cart"];
                List<Item> cart = ViewBag.cart;
                 int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                }
                //Session["cart"] = cart;
                ViewBag.cart = cart;
            }
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            //List<Item> cart = (List<Item>)Session["cart"];
            List<Item> cart = ViewBag.cart;
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }

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
/* From online as well:
         public static Cart GetCart(IServiceProvider services)
         {
         ISession session = services.GetRequiredService<IHttpContextAccessor>()?
         .HttpContext.Session;

        var context = services.GetService<AppDbContext>();
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);

        return new ShoppingCart(context) {CartId = cartId);
        }
        */



/* 
public void AddToCart(Product product, int quantity)
{
var CartItem = 
_appDbContext.CartItems.SingleOrDefault( s => s.Product.ProductId == product.ProductId && s.CartId == CartId )

if (CartItem == null)
{
CartItem = new CartItem 
{
CartId = CartId, 
Product = product, 
ProductQty = 1
};

_appDbContext.CartItems.Add(CartItem);
}
else
{
CartItem.ProductQty++;
}
_appDbContext.SaveChanges();
}
*/

/* public void ClearCart()
 {
 var CartItems = _appDbContext
 .ShoppingCartItems 
 .Where(cart => cart.CartId == CartId);

_appDbContext.CartItems.RemoveRange(cartItems);
_appDbContext.SaveChanges();
*/


/*public class AddProducts
{
public bool AddProduct(string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath)
{
var myProduct = new Product();
myProduct.ProductName = ProductName;
myProduct.Description = ProductDesc;
myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
myProduct.ImagePath = ProductImagePath;
myProduct.CategoryID = Convert.ToInt32(ProductCategory);

using (ProductContext _db = new ProductContext())
{
// Add product to DB.
_db.Products.Add(myProduct);
_db.SaveChanges();
}
// Success.
return true;
}
}
}
}
*/

/*
 * 
public class ShoppingCartActions : IDisposable
{
public string ShoppingCartId { get; set; }

private ProductContext _db = new ProductContext();

public const string CartSessionKey = "CartId";

public void AddToCart(int id)
{
// Retrieve the product from the database.           
ShoppingCartId = GetCartId();

var cartItem = _db.ShoppingCartItems.SingleOrDefault(
  c => c.CartId == ShoppingCartId
  && c.ProductId == id);
if (cartItem == null)
{
// Create a new cart item if no cart item exists.                 
cartItem = new CartItem
{
  ItemId = Guid.NewGuid().ToString(),
  ProductId = id,
  CartId = ShoppingCartId,
  Product = _db.Products.SingleOrDefault(
   p => p.ProductID == id),
  Quantity = 1,
  DateCreated = DateTime.Now
};

_db.ShoppingCartItems.Add(cartItem);
}
else
{
// If the item does exist in the cart,                  
// then add one to the quantity.                 
cartItem.Quantity++;
}
_db.SaveChanges();
}

public void Dispose()
{
if (_db != null)
{
_db.Dispose();
_db = null;
}
}

public string GetCartId()
{
if (HttpContext.Current.Session[CartSessionKey] == null)
{
if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
{
  HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
}
else
{
  // Generate a new random GUID using System.Guid class.     
  Guid tempCartId = Guid.NewGuid();
  HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
}
}
return HttpContext.Current.Session[CartSessionKey].ToString();
}

public List<CartItem> GetCartItems()
{
ShoppingCartId = GetCartId();

return _db.ShoppingCartItems.Where(
  c => c.CartId == ShoppingCartId).ToList();
}

public decimal GetTotal()
{
ShoppingCartId = GetCartId();
// Multiply product price by quantity of that product to get        
// the current price for each of those products in the cart.  
// Sum all product price totals to get the cart total.   
decimal? total = decimal.Zero;
total = (decimal?)(from cartItems in _db.ShoppingCartItems
                 where cartItems.CartId == ShoppingCartId
                 select (int?)cartItems.Quantity *
                 cartItems.Product.UnitPrice).Sum();
return total ?? decimal.Zero;
}
public ShoppingCartActions GetCart(HttpContext context)
{
using (var cart = new ShoppingCartActions())
{
cart.ShoppingCartId = cart.GetCartId();
return cart;
}
}

public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
{
using (var db = new WingtipToys.Models.ProductContext())
{
try
{
  int CartItemCount = CartItemUpdates.Count();
  List<CartItem> myCart = GetCartItems();
  foreach (var cartItem in myCart)
  {
    // Iterate through all rows within shopping cart list
    for (int i = 0; i < CartItemCount; i++)
    {
      if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
      {
        if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
        {
          RemoveItem(cartId, cartItem.ProductId);
        }
        else
        {
          UpdateItem(cartId, cartItem.ProductId, CartItemUpdates[i].PurchaseQuantity);
        }
      }
    }
  }
}
catch (Exception exp)
{
  throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
}
}
}

public void RemoveItem(string removeCartID, int removeProductID)
{
using (var _db = new WingtipToys.Models.ProductContext())
{
try
{
  var myItem = (from c in _db.ShoppingCartItems where c.CartId == removeCartID && c.Product.ProductID == removeProductID select c).FirstOrDefault();
  if (myItem != null)
  {
    // Remove Item.
    _db.ShoppingCartItems.Remove(myItem);
    _db.SaveChanges();
  }
}
catch (Exception exp)
{
  throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
}
}
}

public void UpdateItem(string updateCartID, int updateProductID, int quantity)
{
using (var _db = new WingtipToys.Models.ProductContext())
{
try
{
  var myItem = (from c in _db.ShoppingCartItems where c.CartId == updateCartID && c.Product.ProductID == updateProductID select c).FirstOrDefault();
  if (myItem != null)
  {
    myItem.Quantity = quantity;
    _db.SaveChanges();
  }
}
catch (Exception exp)
{
  throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
}
}
}

public void EmptyCart()
{
ShoppingCartId = GetCartId();
var cartItems = _db.ShoppingCartItems.Where(
  c => c.CartId == ShoppingCartId);
foreach (var cartItem in cartItems)
{
_db.ShoppingCartItems.Remove(cartItem);
}
// Save changes.             
_db.SaveChanges();
}

public int GetCount()
{
ShoppingCartId = GetCartId();

// Get the count of each item in the cart and sum them up          
int? count = (from cartItems in _db.ShoppingCartItems
            where cartItems.CartId == ShoppingCartId
            select (int?)cartItems.Quantity).Sum();
// Return 0 if all entries are null         
return count ?? 0;
}

public struct ShoppingCartUpdates
{
public int ProductId;
public int PurchaseQuantity;
public bool RemoveItem;
}

public void MigrateCart(string cartId, string userName)
{
var shoppingCart = _db.ShoppingCartItems.Where(c => c.CartId == cartId);
foreach (CartItem item in shoppingCart)
{
item.CartId = userName;
}
HttpContext.Current.Session[CartSessionKey] = userName;
_db.SaveChanges();
}
}
}*/
