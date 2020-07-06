using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookDataAccessLibrary
{
    public class User
    {
        public string Username { get; set; }
        private string _password = string.Empty;
        public string Password 
        {
            get
            {
                return _password;
            }
            set 
            {
                byte[] data = Encoding.ASCII.GetBytes(value);
                _password = Convert.ToBase64String(data);                
            } 
        }

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
    }

}
