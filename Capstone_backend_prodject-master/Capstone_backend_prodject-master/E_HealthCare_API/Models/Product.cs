using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_HealthCare_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public string Uses { get; set; }

        public string ExpireDate { get; set; }
    }
}
