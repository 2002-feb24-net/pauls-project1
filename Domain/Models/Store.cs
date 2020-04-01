using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Store
    {
        private string _location;
        private long _phoneNumber;
        public int StoreId { get; set; }
        public string Location 
        {
            get => _location;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Location must not be empty.", nameof(value));
                }
                _location = value;
            }
        }

        public long PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value >= 1000000000 && value <= 9999999999)
                {
                    _phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Must be a valid 10 digit number", nameof(value));
                }
            }
        }
    }
}
