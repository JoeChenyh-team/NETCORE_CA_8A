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
        public string Id { get; set; }

        [Required] 
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


    }
}
