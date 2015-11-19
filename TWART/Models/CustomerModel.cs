using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class CustomerModel
    {
        private MySqlConnection connect;
        private string _connectionString;
        
        public CustomerModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public void EditCustomer(Customer c)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditCustomer";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("CustomerID", c.ID);
                        cmd.Parameters.AddWithValue("CustomerName", c.Name);
                        cmd.Parameters.AddWithValue("AddressID", c.Address_ID);


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


        public void DeleteCustomer(int ID) 
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteCustomer";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("CustomerID", ID);


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
        public Customer SearchCustomers(int ID)
        {
            var cust = new Customer();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetCustomer";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("CustomerID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cust.ID = (int)reader["Customer_ID"];
                        cust.Name = reader["Company_name"].ToString();
                        cust.Address_ID = (int)reader["Address_ID"];

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return cust;
            }
        }

        // Calls main method for getting a customer
        public Customer SearchCustomers(Customer c)
        {
            return SearchCustomers(c.ID);
        }

        // List all customers
        public List<Customer> ListCustomers()
        {
            var cl = new List<Customer>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListCustomer";
                    var cmd = new MySqlCommand(query, connect) {CommandType = CommandType.StoredProcedure};

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var c = new Customer();

                        c.ID = (int) reader["Customer_ID"];
                        c.Name = reader["Company_name"].ToString();
                        c.Address_ID = (int) reader["Address_ID"];

                        cl.Add(c);

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return cl;
            }
        }

        // Finds customers that have the deatils specified in the address object.
        public List<Customer> SearchCustomers(Address a)
        {
            throw new NotImplementedException();
        }

        // Changes the customer specifed by the customer object account type to the Account_Type object.
        public void ChangeAccountType(Customer c, Account_Type type)
        {
            throw new NotImplementedException();
        }

    }
}