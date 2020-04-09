using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_CA_8A.Models
{
    public class Purchase
    {
        internal object PurchaseDate;

        [MaxLength(36)] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string OrderId { get; set; }

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerId { get; set; }

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProductId { get; set; }

        [Required]
        [MaxLength(3)]
        public double ProductQty { get; set; }

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PurchaseKey { get; set; }

        [Required]
        [MaxLength(36)]
        public System.DateTime DateCreated { get; set; }


    }
}
