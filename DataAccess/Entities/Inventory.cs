using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int StoreId { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Stores Store { get; set; }
    }
}
