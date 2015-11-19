using System;
using System.Collections.Generic;
using System.Data;
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
            var addressList = new List<Address>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListAddress";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };


                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        var a = new Address();

                        a.ID = int.Parse(reader["Address_ID"].ToString());
                        a.LineOne = reader["Address_Line1"].ToString();

                        if(reader["Address_Line2"] != null)
                        {
                                a.LineTwo = reader["Address_Line2"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.LineThree = reader["Address_Line3"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.LineFour = reader["Address_Line4"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.LineFive = reader["Address_Line5"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.State = reader["State"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.County = reader["County"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            a.Country = reader["Country"].ToString();
                        }

                        a.PostalCode = reader["Postal_Code"].ToString();

                        addressList.Add(a);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return addressList;
            }
        }

        // This is the main method to get an address.
        public Address SearchAddress(int ID)
        {
            var address = new Address();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetAddress";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("AddressID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        address.ID = int.Parse(reader["Address_ID"].ToString());
                        address.LineOne = reader["Address_Line1"].ToString();

                        if (reader["Address_Line2"] != null)
                        {
                            address.LineTwo = reader["Address_Line2"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.LineThree = reader["Address_Line3"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.LineFour = reader["Address_Line4"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.LineFive = reader["Address_Line5"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.State = reader["State"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.County = reader["County"].ToString();
                        }
                        if (reader["Address_Line2"] != null)
                        {
                            address.Country = reader["Country"].ToString();
                        }

                        address.PostalCode = reader["Postal_Code"].ToString();

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return address;
            }
        }

        // Method calls main method for getting addressed
        public Address SearchAddress(Address a)
        {
            return SearchAddress(a.ID);
        }

        // This method is used to get a list of addresses containing element in the address object.
        public List<Address> SearchAddressesByAddress(Address a)
        {
            throw new NotImplementedException();   
        }

    }
}