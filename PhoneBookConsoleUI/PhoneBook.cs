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
            if (ContactList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No contacts!!!");
                Console.WriteLine();
                Console.ResetColor();
                return;
            }

            var ordered = ContactList.OrderBy(x => x.Value.FirstName).ThenBy(x => x.Value.LastName);
            foreach (var contact in ordered)
            {
                ConsoleLogging.PrintContactInfo(contact.Key, contact.Value);
            }
        }

        internal static void DeleteContact(int id)
        {
            if(id == 0)
            {
                return;
            }
            else if (ContactList.Remove(id))
            {
                Console.WriteLine("Contact removed!");
            }
            else
            {
                ConsoleLogging.DeleteContactErrorText();
            }
        }

        internal static void UpdateContact(int id)
        {
            if(id == 0)
            {
                return;
            }
            else if (ContactList.ContainsKey(id))
            {
                do
                {
                    Console.Clear();

                    Contact c = GetContactFromList(id);
                    ConsoleLogging.PrintContactInfo(id, c);

                    Console.WriteLine("What do you want to update?");
                    string propertyToUpdate = Console.ReadLine();
                    UpdateProperty(c, propertyToUpdate);                    

                } while (ConsoleLogging.UpdateAgain());
            }
            else
            {
                ConsoleLogging.ContactDoesNotExist();
            }
        }

        private static Contact GetContactFromList(int id)
        {
            Contact c;
            while (!ContactList.TryGetValue(id, out c))
            {
                ConsoleLogging.ContactDoesNotExist();
                id = ConsoleLogging.GetContactToUpdate();
            }
            return c;
        }

        private static void UpdateProperty(Contact c, string propertyToUpdate)
        {
            switch (propertyToUpdate.ToLower())
            {
                case "first name":
                    c.FirstName = ConsoleLogging.GetContactInfo("new first name");
                    break;
                case "last name":
                    c.LastName = ConsoleLogging.GetContactInfo("new last name");
                    break;
                case "phone number":
                    c.PhoneNumber = ConsoleLogging.GetContactInfo("new phone number");
                    break;
                case "address":
                    c.Address = ConsoleLogging.GetContactInfo("new address");
                    break;
                case "email address":
                case "email":
                    c.EmailAddress = ConsoleLogging.GetContactInfo("new email address");
                    break;
                case "dob":
                case "birthday":
                    c.DOB = ConsoleLogging.GetContactInfo();
                    break;
                default:
                    ConsoleLogging.InvalidInputText();
                    Console.Write("Please press enter . . . ");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
