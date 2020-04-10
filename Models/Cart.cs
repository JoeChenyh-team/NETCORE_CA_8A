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
        //Joe: insert AppDB Service?? Not sure how to do it but I copy this from online. 
        /*
        private readonly AppDbContext _appDbContext;
        private Cart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        */


        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MaxLength(3)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(36)]
        public System.DateTime DateCreated { get; set; }

        [MaxLength(36)]
        public string CustomerId { get; set; }


        [Required]
        [MaxLength(36)]
        public int ProductId { get; set; }



        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

        

    }
}
