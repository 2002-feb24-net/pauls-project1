using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }
        public long PhoneNumber { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
