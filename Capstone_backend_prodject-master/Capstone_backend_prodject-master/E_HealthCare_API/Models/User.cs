using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_HealthCare_API.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Accountnumber { get; set; }

        public double funds { get; set; }
    }
}
