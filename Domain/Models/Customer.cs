using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private long _phoneNumber;
        public int Id { get; set; }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _lastName = value;
            }
        }
        public string Address { get; set; }
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
