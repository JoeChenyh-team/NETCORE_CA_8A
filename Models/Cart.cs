﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE_CA_8A.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreationTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CheckoutTime { set; get; }
        public int IsCheckOut { get; set; }

        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public string SessionId { get; set; }

        public Cart()
        {
        }

        //public Cart(int customerId)
        public Cart(string SessionId, int CustomerId = 0)
        {
            //this.CustomerId = customerId;
            this.SessionId = SessionId;
            this.CreationTime = DateTime.Now;
            this.IsCheckOut = 0;
            this.CustomerId = CustomerId;
            
        }
    }

    
}
