using Microsoft.VisualBasic.CompilerServices;
using NETCORE_CA_8A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//We use this DBSeeder.cs to 'hardcode' the customers and products. 

namespace NETCORE_CA_8A.DB
{
    public class DBSeeder
    {
        private List<Product> products;
        public DBSeeder(StoreDbContext dbcontext)
        {
            Customer cust1 = new Customer();
            //cust1.Id = Guid.NewGuid().ToString();
            cust1.Id = 1;
            cust1.Name = "amanda";
            cust1.Password = Utils.Crypto.Sha256(cust1.Name);
            dbcontext.Add(cust1);

            Customer cust2 = new Customer();
            cust2.Id = 2;
            cust2.Name = "joe";
            cust2.Password = Utils.Crypto.Sha256(cust2.Name);
            dbcontext.Add(cust2);

            Customer cust3 = new Customer();
            cust3.Id = 3;
            cust3.Name = "esther";
            cust3.Password = Utils.Crypto.Sha256(cust3.Name);
            dbcontext.Add(cust3);

            Category cat1 = new Category();
            cat1.Id = Guid.NewGuid().ToString();
            cat1.catName = ".NET";
            dbcontext.Add(cat1);

            Category cat2 = new Category();
            cat2.Id = Guid.NewGuid().ToString();
            cat2.catName = "MS";
            dbcontext.Add(cat2);

            /*
            Category cat3 = new Category();
            cat3.Id = Guid.NewGuid().ToString();
            cat3.catName = "ADO";
            dbcontext.Add(cat3);
            */

           Product product1 = new Product();
            // product1.Id = Guid.NewGuid().ToString();
           product1.Id = "1";
           product1.productName = ".NetCharts";
           product1.description = "Brings powerful charting capabilities to your .Net applications";
           product1.unitPrice = (decimal)99.00;
           product1.CategoryId = cat1.Id;
           product1.Image = "https://localhost:44331/lib/images/Charts.JPG";
            product1.URL = "https://localhost:44331/Product/View/product1";
           dbcontext.Add(product1);

           Product product2 = new Product();
            // product2.Id = Guid.NewGuid().ToString();
            product2.Id = "2";
            product2.productName = ".NetPaypal";
           product2.description = "Integrate your .Net apps with Paypal the easy way";
           product2.unitPrice = (decimal)69.00;
           product2.CategoryId = cat1.Id;
            product2.Image = "https://localhost:44331/lib/images/Paypal.JPG";
            product2.URL = "https://localhost:44331/Product/View/product2";
            dbcontext.Add(product2);

            Product product3 = new Product();
             product3.Id = Guid.NewGuid().ToString();
             product3.productName = ".NetML";
             product3.description = "Supercharges .NET machine learning libraries";
             product3.unitPrice = 299.00;
             product3.CategoryId = cat1.Id;
             product3.Image = "https://localhost:44331/lib/images/ML.JPG";
             product3.URL = "https://localhost:44331/Product/View/product3";
            dbcontext.Add(product3);

             Product product4 = new Product();
             product4.Id = Guid.NewGuid().ToString();
             product4.productName = ".NetAnalytics";
             product4.description = "Perform data mining and analytics easily in .NET";
             product4.unitPrice = 299.00;
             product4.CategoryId = cat1.Id;
             product4.Image = "https://localhost:44331/lib/images/Analytics.JPG";
             product4.URL = "https://localhost:44331/Product/View/product4";
             dbcontext.Add(product4);

             Product product5 = new Product();
             product5.Id = Guid.NewGuid().ToString();
             product5.productName = ".NetLogger";
             product5.description = "Logs and aggregates events easily in your .NET apps";
             product5.unitPrice = 49.00;
             product5.CategoryId = cat1.Id;
             product5.Image = "https://localhost:44331/lib/images/Logger.JPG";
             product5.URL = "https://localhost:44331/Product/View/product5";
             dbcontext.Add(product5);

             Product product6 = new Product();
             product6.Id = Guid.NewGuid().ToString();
             product6.productName = ".NetNumerics";
             product6.description = "Powerful numerical methods for your .NET simulations";
             product6.unitPrice = 199.00;
             product6.CategoryId = cat1.Id;
             product6.Image = "https://localhost:44331/lib/images/numerics.JPG";
             product6.URL = "https://localhost:44331/Product/View/product6";
             dbcontext.Add(product6);

             Product product7 = new Product();
             product7.Id = Guid.NewGuid().ToString();
             product7.productName = "MS Access";
             product7.description = "Powerful Access methods to store data.";
             product7.unitPrice = 600.00;
             product7.CategoryId = cat2.Id;
             dbcontext.Add(product7);

             Product product8 = new Product();
             product8.Id = Guid.NewGuid().ToString();
             product8.productName = "MS Outlook";
             product8.description = "Powerful application to access your emails.";
             product8.unitPrice = 999.00;
             product8.CategoryId = cat2.Id;
             dbcontext.Add(product8);

             Product product9 = new Product();
             product9.Id = Guid.NewGuid().ToString();
             product9.productName = "MS Visual Studio";
             product9.description = "Powerful tool for you to program more programs";
             product9.unitPrice = 900.00;
             product9.CategoryId = cat2.Id;
             dbcontext.Add(product9);

              Purchase purchase1 = new Purchase();
              purchase1.CartId = Guid.NewGuid().ToString();
              purchase1.CustomerId = cust2.Id;
              purchase1.ProductId = product1.Id;
              purchase1.PurchaseQty = 1;
              purchase1.UTCPurchaseDate = new DateTime(2015, 12, 25);
              purchase1.ActivationKey = "12345";
              dbcontext.Add(purchase1);


              /*
              Product product10 = new Product();
              product7.Id = Guid.NewGuid().ToString();
              product7.productName = "";
              product7.description = "";
              product7.unitPrice = ;
              product7.CategoryId = cat3.Id;
              dbcontext.Add(product7);
              */

            Recommendation recommendation1 = new Recommendation();
            recommendation1.Id = Guid.NewGuid().ToString();
            recommendation1.Product.Id = product1.Id;
            recommendation1.RecommendedProductId1 = product2.Id;
            recommendation1.RecommendedProductId2 = product3.Id;
            recommendation1.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation1);

            Recommendation recommendation2 = new Recommendation();
            recommendation2.Id = Guid.NewGuid().ToString();
            recommendation2.Product.Id = product2.Id;
            recommendation2.RecommendedProductId1 = product2.Id;
            recommendation2.RecommendedProductId2 = product3.Id;
            recommendation2.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation2);

            Recommendation recommendation3 = new Recommendation();
            recommendation3.Id = Guid.NewGuid().ToString();
            recommendation3.Product.Id = product3.Id;
            recommendation3.RecommendedProductId1 = product2.Id;
            recommendation3.RecommendedProductId2 = product3.Id;
            recommendation3.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation3);

            Recommendation recommendation4 = new Recommendation();
            recommendation4.Id = Guid.NewGuid().ToString();
            recommendation4.Product.Id = product4.Id;
            recommendation4.RecommendedProductId1 = product2.Id;
            recommendation4.RecommendedProductId2 = product3.Id;
            recommendation4.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation4);

            Recommendation recommendation5 = new Recommendation();
            recommendation5.Id = Guid.NewGuid().ToString();
            recommendation5.Product.Id = product5.Id;
            recommendation5.RecommendedProductId1 = product2.Id;
            recommendation5.RecommendedProductId2 = product3.Id;
            recommendation5.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation5);

            Recommendation recommendation6 = new Recommendation();
            recommendation6.Id = Guid.NewGuid().ToString();
            recommendation6.Product.Id = product6.Id;
            recommendation6.RecommendedProductId1 = product2.Id;
            recommendation6.RecommendedProductId2 = product3.Id;
            recommendation6.RecommendedProductId3 = product4.Id;
            dbcontext.Add(recommendation6);

            Review review1 = new Review();
            review1.CustomerId = cust1.Id;
            review1.ProductId = product1.Id;
            review1.Stars = 5;
            review1.Comments = "Good product";
            dbcontext.Add(review1);

            Review review2 = new Review();
            review2.CustomerId = cust2.Id;
            review2.ProductId = product2.Id;
            review2.Stars = 3;
            review2.Comments = "I do not like this product";
            dbcontext.Add(review2);

            Review review3 = new Review();
            review3.CustomerId = cust3.Id;
            review3.ProductId = product3.Id;
            review3.Stars = 4;
            review3.Comments = "Not bad";
            dbcontext.Add(review3);






            dbcontext.SaveChanges();
        }
    }
}

/*  For reference (from Wing Tips project): 
   public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductContext>
  {
    protected override void Seed(ProductContext context)
    {
      GetCategories().ForEach(c => context.Categories.Add(c));
      GetProducts().ForEach(p => context.Products.Add(p));
    }
    */