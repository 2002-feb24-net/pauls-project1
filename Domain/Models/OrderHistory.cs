using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class OrderHistory
    {
        private string _order;
        private decimal? _totalPrice;
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }
        public int StoreId { get; set; }
        public DateTime DateTime 
        { 
            get => DateTime; 
            set 
            {
                DateTime = DateTime.Now;
            }
        }
        public string Order
        {
            get => _order;
            set => _order = value ?? "";
        }
        public decimal? TotalPrice 
        { 
            get => _totalPrice; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must not be negative.", nameof(value));
                }
                _totalPrice = value;
            }
        }

    }
}
