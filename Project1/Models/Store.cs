using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Store
    {
        [Display(Name = "Store Number")]
        public int StoreId { get; set; }

        [Required]
        public int Location { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public long PhoneNumber { get; set; }

    }
}
