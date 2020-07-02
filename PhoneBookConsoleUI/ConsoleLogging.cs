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
            Console.WriteLine("Please enter the contacts first name.");
            c.FirstName = Console.ReadLine();
            Console.WriteLine("\nPlease enter their last name.");
            c.LastName = Console.ReadLine();
            Console.WriteLine("\nPlease enter their telephone number.");
            c.PhoneNumber = Console.ReadLine();
            Console.WriteLine("\nPlease enter their email address.");
            c.EmailAddress = Console.ReadLine();
            Console.WriteLine("\nPlease enter their address.");
            c.Address = Console.ReadLine();
            c.DOB = GetContactDOB();
        }

        internal static DateTime GetContactDOB()
        {
            Console.WriteLine("\nPlease enter their date of birth. ex: dd/mm/yyyy");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid format please type the date of birth in any of the following format:");
                Console.Write("dd/mm/yyyy");
                Console.ResetColor();
            }
            return dob;
        }

        internal static int GetContactToDelete()
        {
            Console.WriteLine("Which contact do you want to delete? Please enter the id!");
            PhoneBook.GetAllContacts();

            int id;
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Please try again, that was an improper format.");
            }

            return id;
        }

        internal static void DeleteContactErrorText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error has occurred, cannot delete that contact. Try again!");
            Console.ResetColor();
        }
    }
}