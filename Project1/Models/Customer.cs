using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Customer
    {
        [Display(Name = "ID Number")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [MaxLength(280)]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public long PhoneNumber { get; set; }
    }
}
