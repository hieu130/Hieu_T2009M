using Microsoft.Data.Sqlite;
using Practice.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Practice.Models
{
   public class ContactModels
    {   
        public static bool Save(Contact contact)
        {
            try
            {
                string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
                using (SqliteConnection db =
                   new SqliteConnection($"Filename={dbpath}"))
                {
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    insertCommand.CommandText = "INSERT INTO contact (name_contact, phone_number) VALUES (@Name, @Phone);";
                    insertCommand.Parameters.AddWithValue("@Name", contact.Name);
                    insertCommand.Parameters.AddWithValue("@Phone", contact.Phone);
                    insertCommand.ExecuteReader();
                    return true;
                }
                }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static Contact SearchByName(string name)
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
                using (SqliteConnection db =
                     new SqliteConnection($"Filename={dbpath}"))
                {
                    SqliteCommand selectCommand = new SqliteCommand();
                    selectCommand.Connection = db;
                    selectCommand.CommandText = $"select * from contact where name like ' {name}';";
                    SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    var contact = new Contact()
                    {
                        Name = query.GetString(1),
                        Phone = query.GetString(2),
                    };
                    contacts.Add(contact);
                }
                if(contacts.Count > 0)
                {
                    return contacts[0];
                }
                }                  
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }
        public static List<Contact> GetContact()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
                using (SqliteConnection db =
                     new SqliteConnection($"Filename={dbpath}"))
                {
                    SqliteCommand selectCommand = new SqliteCommand();
                    selectCommand.Connection = db;
                    selectCommand.CommandText = $"select * from contact";
                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        var contact = new Contact()
                        {
                            Name = query.GetString(1),
                            Phone = query.GetString(2),
                        };
                        contacts.Add(contact);
                    }
                    }
            }
            catch (Exception e)
            {
                return null;
            }
            return contacts;
        } 

    }
}
