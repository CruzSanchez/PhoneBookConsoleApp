using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookDataAccessLibrary
{
    public class Contact
    {
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime DOB { get; set; }

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = Regex.Replace(value, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"); }
        }

    }
}
