﻿using PhoneBookDataAccessLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PhoneBookConsoleUI
{
    public class Contact : IContact
    {        
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