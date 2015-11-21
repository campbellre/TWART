using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class ContactModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public ContactModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateContact(Contact c)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewContact";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PForename", c.Forename);
                        cmd.Parameters.AddWithValue("PSurname", c.Surname);
                        cmd.Parameters.AddWithValue("JobTitle", c.Position);
                        cmd.Parameters.AddWithValue("TelNumber", c.PhoneNumber);


                        ret = int.Parse(cmd.ExecuteScalar().ToString());

                        transaction.Commit();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
            return ret;
        }

        public void EditContact(Contact c)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditContact";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("ContactID", c.ID);
                        cmd.Parameters.AddWithValue("PForename", c.Forename);
                        cmd.Parameters.AddWithValue("PSurname", c.Surname);
                        cmd.Parameters.AddWithValue("JobTitle", c.Position);
                        cmd.Parameters.AddWithValue("TelNumber", c.PhoneNumber);


                        cmd.ExecuteNonQuery();

                        transaction.Commit();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
        }


        public void DeleteContact(int ID) 
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteContact";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("ContactID", ID);


                        cmd.ExecuteNonQuery();

                        transaction.Commit();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
        }

        
        // Main method for getting a customer
        public Contact SearchContact(int ID)
        {
            var contact = new Contact();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetContact";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("ContactID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contact.ID = (int)reader["Contact_ID"];
                        contact.Forename = reader["Forename"].ToString();
                        contact.Surname = reader["Surname"].ToString();
                        contact.Position = reader["Job_Title"].ToString();
                        contact.PhoneNumber = reader["Tel_Number"].ToString();
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return contact;
            }
        }

        // Calls main method for getting a customer
        public Contact SearchContact(Contact c)
        {
            return SearchContact(c.ID);
        }

        // List all customers
        public List<Contact> ListContacts()
        {
            var contactList = new List<Contact>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListContact";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var contact = new Contact();
                        contact.ID = (int)reader["Contact_ID"];
                        contact.Forename = reader["Forename"].ToString();
                        contact.Surname = reader["Surname"].ToString();
                        contact.Position = reader["Job_Title"].ToString();
                        contact.PhoneNumber = reader["Tel_Number"].ToString();

                        contactList.Add(contact);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return contactList;
            }
        }


    }
}