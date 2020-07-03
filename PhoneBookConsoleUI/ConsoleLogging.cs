using System;

namespace PhoneBookConsoleUI
{
    internal class ConsoleLogging
    {
        internal static void IntroText()
        {
            Console.WriteLine("Welcome to your phone book!");
            Console.WriteLine();
            Console.WriteLine("What action would you like to perform?");
            Console.WriteLine();
        }

        internal static void WhichActionText()
        {
            Console.WriteLine("1 - Create a contact");
            Console.WriteLine("2 - Read all contacts");
            Console.WriteLine("3 - Update a contact");
            Console.WriteLine("4 - Delete a contact");            
            Console.WriteLine("5 - End Application");            
        }

        internal static void PrintContactInfo(int key, Contact c)
        {
            Console.WriteLine($"Id: {key}| Name: {c.FullName}| Number: {c.PhoneNumber}| Email: {c.EmailAddress}|" +
                $" Address:{c.Address}| Date of Birth:{c.DOB.ToShortDateString()}");
        }

        internal static void GetUserInformation(Contact c)
        {
            c.FirstName = GetContactInfo("first name");
            c.LastName = GetContactInfo("last name");
            c.PhoneNumber = GetContactInfo("phone number");
            c.EmailAddress = GetContactInfo("email address");
            c.Address = GetContactInfo("address");
            c.DOB = GetContactInfo();
        }

        private static string GetContactInfo(string infoToGet)
        {
            Console.WriteLine($"\nPlease enter their {infoToGet}.");
            return Console.ReadLine();
        }        

        internal static DateTime GetContactInfo()
        {
            Console.WriteLine("\nPlease enter their date of birth. ex: dd/mm/yyyy");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                InvalidInputText("mm/dd/yyyy");
            }
            return dob;
        }

        internal static int GetContactToDelete()
        {
            Console.WriteLine("Which contact do you want to delete? Please select based on the id.");
            PhoneBook.GetAllContacts();

            int id;
            id = GetIdSafely();

            return id;
        }

        internal static int GetContactToUpdate()
        {
            Console.WriteLine("Which contact do you want to update? Please select based on the id.");
            PhoneBook.GetAllContacts();

            int id;
            id = GetIdSafely();

            return id;
        }

        private static int GetIdSafely()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                InvalidInputText();
            }

            return id;
        }

        private static void InvalidInputText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please try again, that was an invalid format.");
            Console.ResetColor();
        }

        private static void InvalidInputText(string properFormat)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please try again, that was an invalid format.");
            Console.WriteLine($"This is the correct format: {properFormat}");
            Console.ResetColor();
        }

        internal static void DeleteContactErrorText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error has occurred, cannot delete that contact. Try again!");
            Console.ResetColor();
        }
    }
}