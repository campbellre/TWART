using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class AddressModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public AddressModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public void CreateAddress(Address a)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAddressesList()
        {
            throw new NotImplementedException();
        }

        // This is the main method to get an address.
        public Address GetAddress(int ID)
        {
            throw new NotImplementedException();
        }

        // Method calls main method for getting addressed
        public Address GetAddress(Address a)
        {
            return GetAddress(a.ID);
        }

        // This method is used to get a list of addresses containing element in the address object.
        public List<Address> GetAddressesByAddress(Address a)
        {
            throw new NotImplementedException();   
        }

    }
}