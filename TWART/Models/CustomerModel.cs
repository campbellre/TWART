using System;
using System.Collections.Generic;
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

        public void CreateCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        // Main method for getting a customer
        public Customer SearchCustomers(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls main method for getting a customer
        public Customer SearchCustomers(Customer c)
        {
            return SearchCustomers(c.ID);
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