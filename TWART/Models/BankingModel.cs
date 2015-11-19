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
    public class BankingModel
    {
        private MySqlConnection connect;
        private string _connectionString;
        public BankingModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public Bank SearchBanking(Customer c)
        {
            var bank = new Bank();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "SearchBankingCustomer";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("CustomerID", c.ID);
                    cmd.Parameters.AddWithValue("CustomerName", c.Name);
                    cmd.Parameters.AddWithValue("AddressID", c.Address_ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        bank.ID = int.Parse(reader["Banking_ID"].ToString());
                        bank.Address_ID = int.Parse(reader["Address_ID"].ToString());
                        bank.SortCode = reader["Sort_Code"].ToString();
                        bank.AccountNumber = int.Parse(reader["Account_Number"].ToString());

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return bank;
            }
        }
    }
}