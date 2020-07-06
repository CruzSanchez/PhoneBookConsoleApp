using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PhoneBookDataAccessLibrary
{
    public class FileMaster
    {
        private static string _filePath = $@"{Directory.GetCurrentDirectory()}/ContactList.json";
        private static string _userFilePath = $@"{Directory.GetCurrentDirectory()}/Users.json";

        #region ContactsJSON
        public static Dictionary<int, ContactModel> ReadContactFile()
        {
            Dictionary<int, ContactModel> contacts = new Dictionary<int, ContactModel>();
            int key = 0;

            if (File.Exists(_filePath))
            {
                var text = File.ReadAllText(_filePath);
                try
                {
                    var jArray = JArray.Parse(text);
                    foreach (var token in jArray)
                    {
                        ++key;
                        var contact = JsonConvert.DeserializeObject<ContactModel>(token.ToString());
                        contacts.Add(key, contact);
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                File.Create(_filePath);
            }

            return contacts;
        }

        public static void WriteContactFile(Dictionary<int, ContactModel> contactDictionary)
        {
            var text = JsonConvert.SerializeObject(contactDictionary.Values, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
        #endregion

        #region UsersJSON
        public static User ReadUserFile()
        {
            User user = null;

            if (File.Exists(_userFilePath))
            {
                var text = File.ReadAllText(_userFilePath);
                try
                {
                    var jObject = JObject.Parse(text);
                    user = JsonConvert.DeserializeObject<User>(jObject.ToString());
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                File.Create(_filePath);
            }
            return user;
        }
        public static void WriteUserFile(User user)
        {
            var text = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(_userFilePath, text);
        }
        #endregion
    }
}
