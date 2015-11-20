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
    public class AccountTypeModel
    {

        private MySqlConnection connect;
        private string _connectionString;

        public AccountTypeModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateAccountType(Account_Type a)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewAccountType";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountName", a.Name);
                        cmd.Parameters.AddWithValue("PBenifit", a.Benefit);
                        cmd.Parameters.AddWithValue("PCost", a.Cost);

                        ret = (int)cmd.ExecuteScalar();

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

        public void EditAccount(Account_Type a)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditAccountType";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountTypeID", a.ID);
                        cmd.Parameters.AddWithValue("AccountName", a.Name);
                        cmd.Parameters.AddWithValue("PBenifit", a.Benefit);
                        cmd.Parameters.AddWithValue("PCost", a.Cost);

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

        public void DeleteAccount(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteAccountType";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountTypeID", ID);

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

        // The main method to get a user account.
        public Account_Type SearchAccountType(int ID)
        {
            var accountT = new Account_Type();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetAccountType";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("AccountTypeID", ID);
                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        accountT.ID = int.Parse(reader["Account_Type_ID "].ToString());
                        accountT.Name = reader["Account_Name"].ToString();
                        accountT.Benefit = reader["Benefit"].ToString();
                        accountT.Cost = decimal.Parse(reader["Cost "].ToString());
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return accountT;
            }
        }

        public Account_Type SearchAccountType(Account_Type a)
        {
            return SearchAccountType(a.ID);
        }
        public List<Account_Type> ListAccounts()
        {
            var accountList = new List<Account_Type>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListAccountType";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var accountType = new Account_Type();
                        accountType.ID = int.Parse(reader["Account_Type_ID "].ToString());
                        accountType.Name = reader["Account_Name"].ToString();
                        accountType.Benefit = reader["Benefit"].ToString();
                        accountType.Cost = decimal.Parse(reader["Cost "].ToString());



                        accountList.Add(accountType);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return accountList;
            }
        }

    }
}