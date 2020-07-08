using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using PhoneBookDataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PhoneBookConsoleUI
{
    internal static class Startup
    {
        internal static IContainer ConfigureContainer(string connString)
        {
            var container = new Container(x =>
            {
                x.AddTransient<IDbConnection>((c) => 
                {
                    return new MySqlConnection(connString);
                });
                x.AddTransient<IContactRepository, ContactRepository>();
            });

            return container;
        } 

        internal static IConfiguration InitializeSQLConfig()
        {
            return new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();
        }

        internal static string GetConnectionString()
        {
            return InitializeSQLConfig().GetConnectionString("DefaultConnection");
        }
    }
}
