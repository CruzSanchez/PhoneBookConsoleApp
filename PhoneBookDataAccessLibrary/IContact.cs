using System;

namespace PhoneBookDataAccessLibrary
{
    public interface IContact
    {
        string Address { get; set; }
        DateTime DOB { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string FullName { get; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}