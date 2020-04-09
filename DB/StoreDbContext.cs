using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using NETCORE_CA_8A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//We use StoreDBContext to store all the get set functions 

namespace NETCORE_CA_8A.DB
{
    public class StoreDbContext:DbContext
    {
        protected IConfiguration configuration;
        public StoreDbContext()
        {

        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }

        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<NETCORE_CA_8A.Models.Purchase> Order { get; set; }
    }
}

