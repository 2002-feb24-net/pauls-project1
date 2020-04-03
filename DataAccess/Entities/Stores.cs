using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Inventory = new HashSet<Inventory>();
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int StoreId { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
