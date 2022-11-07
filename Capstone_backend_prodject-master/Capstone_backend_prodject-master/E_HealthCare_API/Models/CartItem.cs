using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_HealthCare_API.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public int UserID { get; set; }

        public int ProductID { get; set; }

        public int Qty { get; set; }

        public string image { get; set; }

        public decimal Amount { get; set; }

        public virtual User User { get; set; }

        public virtual Product Product { get; set; }
       
    }
}
