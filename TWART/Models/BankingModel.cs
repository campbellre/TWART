using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;
using TWART.Views.Admin;

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

                        ret = int.Parse(cmd.ExecuteScalar().ToString());

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

        public List<Bank> ListBanking()
        {
            var bankList = new List<Bank>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListBank";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var b = new Bank();
                        b.ID = int.Parse(reader["Banking_ID"].ToString());
                        b.Address_ID = int.Parse(reader["Address_ID"].ToString());
                        b.SortCode = reader["Sort_Code"].ToString();
                        b.AccountNumber = int.Parse(reader["Account_Number"].ToString());


                        bankList.Add(b);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return bankList;
            }
        }

        public Bank SearchBank(int ID)
        {
            var bank = new Bank();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetBank";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("BankID", ID);

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

        public Bank SearchBank(Bank b)
        {
            return SearchBank(b.ID);
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