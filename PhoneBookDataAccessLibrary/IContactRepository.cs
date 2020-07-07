using System.Collections.Generic;

namespace PhoneBookDataAccessLibrary
{
    public interface IContactRepository
    {
        void CreateContact(ContactModel contact);
        void DeleteContact(ContactModel contact);
        IEnumerable<ContactModel> GetAllContacts();
        ContactModel GetContact(int id);
        void UpdateContact(ContactModel contact);
    }
}