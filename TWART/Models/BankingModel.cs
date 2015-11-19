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

        public int CreateBank(Bank b)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewBanking";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AddressID", b.Address_ID);
                        cmd.Parameters.AddWithValue("SortCode", b.SortCode);
                        cmd.Parameters.AddWithValue("AccountNumber", b.ID);

                        connect.Open();

                        ret = (int) cmd.ExecuteScalar();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        connect.Close();
                    }
                }
            }
            return ret;
        }

        // Due to the transaction we don't change banks we add new ones
        //public int EditBank(Bank b)
        
        // Due to the transaction we don't delete banks we add new ones
        //public void DeleteBank(Bank b)

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