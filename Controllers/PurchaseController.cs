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

//We use this to do the Purchase codes to display past and current purchase of customer 

namespace NETCORE_CA_8A.Controllers
{
    public class PurchaseController : Controller
    {


        protected StoreDbContext _dbcontext;

        private readonly ILogger<PurchaseController> _logger;

        public PurchaseController(StoreDbContext dbcontext, ILogger<PurchaseController> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        /* Purchase purchase1 = new Purchase();
            purchase1.OrderId = Guid.NewGuid().ToString();
purchase1.CustomerId = cust1.Id;
            purchase1.ProductId = product1.Id;
            purchase1.ProductQty = 1;
            purchase1.PurchaseDate = "03/03/2020";
            purchase1.PurchaseKey = "12345";
            dbcontext.Add(purchase1); */

        public IActionResult Purchase(string customerid)
        {
            ViewData["customerid"] = customerid;
            ViewBag.purchase = GetAllPurchase(customerid);
            if (ViewBag.Purchase.Count == null)
            {
                ViewBag.search = "not found";
            }
            else if (ViewBag.Purchase.Count ==0)
            {
                ViewBag.Search = "not found";
            }
            return View();
        }
        
        public List<Purchase> GetAllPurchase(string customerid)
        {
            

            if (customerid == null)
            {
                return null;
            }

            return _dbcontext.Purchase.ToList();
            


        }
    }
}