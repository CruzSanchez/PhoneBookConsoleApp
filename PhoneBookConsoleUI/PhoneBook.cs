using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    static class PhoneBook
    {
        public static Dictionary<int, Contact> ContactList { get; set; }
        private static int _key = 0;

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
            foreach (var contact in ContactList)
            {
                ConsoleLogging.PrintContactInfo(contact.Value);
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
