using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Inventory
    {
        private string _product;
        private decimal? _price;
        private int _leominsterQuantity;
        private int _gardnerQuantity;
        private int _worcesterQuantity;

        public int Id { get; set; }
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
        public int LeominsterQuantity
        {
            get => _leominsterQuantity;
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException("Quantity must not be negative or over 999.", nameof(value));
                }
                _leominsterQuantity = value;
            }
        }
        public int GardnerQuantity
        {
            get => _gardnerQuantity;
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException("Quantity must not be negative or over 999.", nameof(value));
                }
                _gardnerQuantity = value;
            }
        }
        public int WorcesterQuantity
        {
            get => _worcesterQuantity;
            set
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentException("Quantity must not be negative or over 999.", nameof(value));
                }
                _worcesterQuantity = value;
            }
        }
    }
}

