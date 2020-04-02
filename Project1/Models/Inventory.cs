using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Inventory
    {
        [Display(Name = "Product ID Number")]
        public int Id { get; set; }

        [Required]
        public string Product { get; set; }

        [Range(0, 999)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }

        [Display(Name = "Leominster Quantity")]
        [Required]
        [Range(0, 999)]
        public int LeominsterQuantity { get; set; }

        [Display(Name = "Gardner Quantity")]
        [Required]
        [Range(0, 999)]
        public int GardnerQuantity { get; set; }

        [Display(Name = "Worcester Quantity")]
        [Required]
        [Range(0, 999)]
        public int WorcesterQuantity { get; set; }
    }
}
