using System;

namespace PhoneBookConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {            
            ConsoleLogging.IntroText();

            do
            {
                ConsoleLogging.WhichActionText();
                var userChoice = Console.ReadKey();
                Console.WriteLine();
                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        PhoneBook.CreateContact();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        PhoneBook.GetAllContacts();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine();
                        Console.WriteLine("You pressed 3");
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        int id = ConsoleLogging.GetContactToDelete();
                        PhoneBook.DeleteContact(id);
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        Console.WriteLine("Thank You!");
                        Environment.Exit(0);
                        break;
                }

            } while (true);
        }
    }
}
