using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<ContactModel> GetAllContacts()
        {
            return _conn.GetAll<ContactModel>();
        }
        public ContactModel GetContact(int id)
        {
            return _conn.Get<ContactModel>(id);
        }
        public void CreateContact(ContactModel contact)
        {
            _conn.Insert(contact);
        }
        public void UpdateContact(ContactModel contact)
        {
            _conn.Update(contact);
        }
        public void DeleteContact(ContactModel contact)
        {
            _conn.Delete(contact);
        }
    }
}
