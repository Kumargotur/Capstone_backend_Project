using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_HealthCare_API.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public int AccNumber { get; set; }

        public int Amount { get; set; }

        public string Email { get; set; }
    }
}
