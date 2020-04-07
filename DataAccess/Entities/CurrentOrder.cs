using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class CurrentOrder
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string CustomerName { get; set; }
        public int? CustomerId { get; set; }
        public string Location { get; set; }
        public int? StoreId { get; set; }
        public string Order { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual OrderHistory OrderNavigation { get; set; }
    }
}
