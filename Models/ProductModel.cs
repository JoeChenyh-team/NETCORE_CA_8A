using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NETCORE_CA_8A.Models
{ 
    
    public class ProductModel
    {
        private List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>() {
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetCharts",
                    description = "Brings powerful charting capabilities to your .Net applications",
                    unitPrice = 99.00,
                    CategoryId = "cat1"
                    

                },
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetPaypal",
                    description = "Integrate your .Net apps with Paypal the easy way",
                    unitPrice = 69.00,
                    CategoryId = "cat1"
        },
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetML",
                    description = "Supercharges .NET machine learning libraries",
                    unitPrice = 299.00,
                    CategoryId = "cat1"
                },

                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetAnalytics",
                    description = "Perform data mining and analytics easily in .NET",
                    unitPrice = 299.00,
                    CategoryId = "cat1"
                },

                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetLogger",
                    description = "Logs and aggregates events easily in your .NET apps",
                    unitPrice = 49.00,
                    CategoryId = "cat1"
                },

                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = ".NetNumerics",
                    description = "Powerful numerical methods for your .NET simulations",
                    unitPrice = 199.00,
                    CategoryId = "cat1"
                },

                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = "MS Access",
                    description = "Powerful Access methods to store data.",
                    unitPrice = 600.00,
                    CategoryId = "cat2"
                },

                
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = "MS Outlook",
                    description = "Powerful application to access your emails.",
                    unitPrice = 999.00,
                    CategoryId = "cat2"
                },

                new Product {
                    Id = Guid.NewGuid().ToString(),
                    productName = "MS Visual Studio",
                    description = "Powerful tool for you to program more programs",
                    unitPrice = 900.00,
                    CategoryId = "cat2"
                },
            };
        }

        public List<Product> findAll()
        {
            return this.products;
        }

        public Product find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }

    }
}
