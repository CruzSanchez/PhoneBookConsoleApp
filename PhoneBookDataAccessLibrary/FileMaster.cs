﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneBookDataAccessLibrary
{
    public class FileMaster
    {
        private static string _filePath = $@"{Directory.GetCurrentDirectory()}/ContactList.json";

        public static Dictionary<int, Contact> ReadFile()
        {
            Dictionary<int, Contact> contacts = new Dictionary<int, Contact>();
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
                        var contact = JsonConvert.DeserializeObject<Contact>(token.ToString());
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

        public static void WriteFile(Dictionary<int, Contact> contactDictionary)
        {
            var text = JsonConvert.SerializeObject(contactDictionary.Values, Formatting.Indented);
            File.WriteAllText(_filePath, text);
        }
    }
}
