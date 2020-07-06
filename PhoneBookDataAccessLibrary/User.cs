using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookDataAccessLibrary
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void SetUserName()
        {
            Username = Console.ReadLine();
        }
        public void SetUserPassword()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                Password += key.KeyChar;
            }
        }
        public bool CheckUserPassword(string possiblePassword)
        {
            return Password == possiblePassword;
        }
    }

}
