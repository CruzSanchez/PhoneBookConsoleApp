using PhoneBookDataAccessLibrary;
using System;
using System.Text;

namespace PhoneBookConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogging.IntroText();

            User user = FileMaster.ReadUserFile();
            if (user == null)
            {
                ConsoleLogging.FirstTimeProfileText();
                user = UserProfileSetup();
            }
            else
            {
                if (LogIn(user))
                {
                    ConsoleLogging.WelcomeText(user.Username);
                }
                else
                {
                    ConsoleLogging.InvaildUser();
                    Environment.Exit(1);
                }
            }

            PhoneBook.ContactList = FileMaster.ReadContactFile();
            if (PhoneBook.ContactList.Count == 0)
            {
                ConsoleLogging.FirstTimeContactText();               

                PhoneBook.CreateContact(0);
            }
            
            Execute(user);
        }

        private static bool LogIn(User user)
        {
            Console.WriteLine("Please log in.");

            ConsoleLogging.UsernameLogin();

            string potentialPassword = ConsoleLogging.PasswordLogin();
            return CheckUserPassword(user.Password, potentialPassword);
        }        

        private static bool CheckUserPassword(string passwordFromFile, string possiblePassword)
        {
            byte[] data = Encoding.ASCII.GetBytes(possiblePassword);
            possiblePassword = Convert.ToBase64String(data);

            return passwordFromFile == possiblePassword;
        }

        private static void Execute(User user)
        {
            int contactId;
            do
            {
                Console.Clear();
                ConsoleLogging.WhichActionText();
                var userChoice = Console.ReadKey();
                Console.WriteLine();
                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        PhoneBook.CreateContact(PhoneBook.ContactList.Count);
                        ConsoleLogging.PressEnter();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        PhoneBook.GetAllContacts();
                        ConsoleLogging.PressEnter();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        contactId = ConsoleLogging.GetContactToUpdate();
                        PhoneBook.UpdateContact(contactId);
                        ConsoleLogging.PressEnter();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        contactId = ConsoleLogging.GetContactToDelete();
                        PhoneBook.DeleteContact(contactId);
                        ConsoleLogging.PressEnter();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        FileMaster.WriteUserFile(user);
                        FileMaster.WriteContactFile(PhoneBook.ContactList);
                        Console.WriteLine("Thank You!");
                        Environment.Exit(0);
                        break;
                }

            } while (true);
        }
        private static User UserProfileSetup()
        {
            User u = new User();
            ConsoleLogging.GetUserNameText();
            u.SetUserName();
            ConsoleLogging.GetPasswordText();
            u.SetUserPassword();
            return u;
        }
    }
}
