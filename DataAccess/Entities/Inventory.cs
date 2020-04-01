using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal? Price { get; set; }
        public int LeominsterQuantity { get; set; }
        public int GardnerQuantity { get; set; }
        public int WorcesterQuantity { get; set; }
    }
}
