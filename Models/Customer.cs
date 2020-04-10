using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_CA_8A.Models
{
    public class Customer
    {
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int  Id{get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Customer() { }

        public Customer(String username, String password)
        {
            this.Name = username;
            this.Password = password;
        }


    }
}
