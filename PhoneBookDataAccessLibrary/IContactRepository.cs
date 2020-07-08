using System.Collections.Generic;

namespace PhoneBookDataAccessLibrary
{
    public interface IContactRepository
    {
        void CreateContact(Contact contact);
        void DeleteContact(Contact contact);
        Dictionary<int, Contact> GetAllContacts();
        Contact GetContact(int id);
        void UpdateContact(Contact contact);
    }
}