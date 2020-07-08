using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PhoneBookDataAccessLibrary
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _conn;

        public ContactRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Dictionary<int, Contact> GetAllContacts()
        {
            var contacts = _conn.GetAll<Contact>();
            return contacts.ToDictionary(c => c.id);
        }
        public Contact GetContact(int id)
        {
            return _conn.Get<Contact>(id);
        }
        public void CreateContact(Contact contact)
        {
            _conn.Insert(contact);
        }
        public void UpdateContact(Contact contact)
        {
            _conn.Update(contact);
        }
        public void DeleteContact(Contact contact)
        {
            _conn.Delete(contact);
        }
    }
}
