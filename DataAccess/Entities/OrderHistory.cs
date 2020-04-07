using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            CurrentOrder = new HashSet<CurrentOrder>();
        }

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }
        public int StoreId { get; set; }
        public DateTime DateTime { get; set; }
        public string Order { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<CurrentOrder> CurrentOrder { get; set; }
    }
}
