using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    static class PhoneBook
    {
        public static Dictionary<int, Contact> ContactList { get; set; }
        private static int _key = 1;

        static PhoneBook()
        {
            ContactList = new Dictionary<int, Contact>();
        }

        internal static void CreateContact()
        {
            Contact contact = new Contact();

            ConsoleLogging.GetUserInformation(contact);

            ContactList.TryAdd(_key, contact);

            _key++;
        }

        internal static void GetAllContacts()
        {
            var ordered = ContactList.OrderBy(x => x.Value.FirstName).ThenBy(x => x.Value.LastName);
            foreach (var contact in ordered)
            {
                ConsoleLogging.PrintContactInfo(contact.Key, contact.Value);
            }
        }

        internal static void DeleteContact(int id)
        {
            if (ContactList.Remove(id))
            {
                Console.WriteLine("Contact removed!");
            }
            else
            {
                ConsoleLogging.DeleteContactErrorText();
            }
        }
    }
}
