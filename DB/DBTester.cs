using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCORE_CA_8A.Models;
using NETCORE_CA_8A.DB;
using Microsoft.AspNetCore.Http;

//We use the DBTester to check for the password authentication. 

namespace NETCORE_CA_8A.DB
{
    public class DBTester
    {
        protected StoreDbContext dbcontext;
        public DBTester(StoreDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public bool CheckAuthentication(string name, string password)
        {
                var pwd = dbcontext.Customers.Where(x => x.Name == name)
                        .Select(x => x.Password).FirstOrDefault();
                if (pwd == null || password != pwd)
                {
                    return false;
                }
                return true;
           
        }
        /*public bool CheckAuthentication(string name, string password)
        {
            using (var dbcontext = new StoreDbContext())
            {
                var pwd = dbcontext.Customers.Where(x => x.Name == name)
                        .Select(x => x.Password).FirstOrDefault();
                if (pwd == null || password != pwd)
                {
                    return false;
                }
                return true;
            }

        }*/

    }
}
