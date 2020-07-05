using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    static class User : IUser
    {
        public static string UserName { get; private set; }
        public static string Password { get; private set; }

        public static void SetUserName()
        {
            UserName = Console.ReadLine();
        }
        public static void SetUserPassword()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                Password += key.KeyChar;
            }
        }
        public static bool CheckUserPassword(string possiblePassword)
        {
            return Password == possiblePassword;
        }
    }

}
