using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            OrderHistory = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
    }
}
