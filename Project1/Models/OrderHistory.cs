using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class OrderHistory
    {
        [Display(Name = "Order Number")]
        public int OrderId { get; set; }

        [Display(Name = "Customer's Name")]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "Customer's Id Number")]
        public int CustomerId { get; set; }

        [Required]
        public int Location { get; set; }

        [Display(Name = "Store Number")]
        public int StoreId { get; set; }

        [Display(Name = "Date & Time Ordered")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [MaxLength(2048)]
        [Required]
        public string Order { get; set; }

        [Display(Name = "Total Price of Order")]
        [Range(0, 999)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? TotalPrice { get; set; }

    }
}
