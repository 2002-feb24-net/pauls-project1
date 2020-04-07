using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.ViewModels
{
    public class CurrentOrder
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string CustomerName { get; set; }
        public int? CustomerId { get; set; }
        public string Location { get; set; }
        public int? StoreId { get; set; }
        public string Order { get; set; }
        public decimal? TotalPrice { get; set; }

        public List<Inventory> Products { get; set; }
    }
}
