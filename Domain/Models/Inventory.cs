using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Inventory
    {
        private string _product;
        private int _quantity;
        private decimal? _price;

        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Product
        {
            get => _product;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Product must not be empty.", nameof(value));
                }
                _product = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException("Quantity must not be negative or over 999.", nameof(value));
                }
                _quantity = value;
            }
        }

        public decimal? Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must not be negative.", nameof(value));
                }
                _price = value;
            }
        }
    }
}

