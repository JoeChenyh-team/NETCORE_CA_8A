using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_CA_8A.Models
{
    public class Purchased
    {
        public int Id { get; set; }
        public int CartItemId { get; set; }
        public string ActivationCode { get; set; }

        public Purchased()
        {
        }

        public Purchased(int cartItemId, string activationCode)
        {
            this.CartItemId = cartItemId;
            this.ActivationCode = activationCode;
        }
    }
}
