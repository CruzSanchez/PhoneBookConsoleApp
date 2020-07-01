using System;

namespace PhoneBookConsoleUI
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
    }
}