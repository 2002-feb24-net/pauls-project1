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

        [Display(Name = "Store Number")]
        [Required]
        public int StoreId { get; set; }

        [Display(Name = "Quantity")]
        [Required]
        [Range(0, 999)]
        public int Quantity { get; set; }

        [Range(0, 999)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Price { get; set; }
    }
}
