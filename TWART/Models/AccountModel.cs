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
    public class AccountModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public AccountModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateAccount(Account a)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewAccount";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("ContactID", a.ContactID);
                        cmd.Parameters.AddWithValue("CustomerID", a.CustomerID);
                        cmd.Parameters.AddWithValue("AccountTypeID", a.AccountTypeID);
                        cmd.Parameters.AddWithValue("BankingID", a.BankID);

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

        public void EditAccount(Account a)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditAccount";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountID", a.ID);
                        cmd.Parameters.AddWithValue("ContactID", a.ContactID);
                        cmd.Parameters.AddWithValue("CustomerID", a.CustomerID);
                        cmd.Parameters.AddWithValue("AccountTypeID", a.AccountTypeID);
                        cmd.Parameters.AddWithValue("BankingID", a.BankID);

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
                        string query = "DeleteAccount";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountID", ID);

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
        public Account SearchAccount(int ID)
        {
            var account = new Account();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetAccount";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        account.ID = int.Parse(reader["Package_ID "].ToString());
                        account.ContactID = int.Parse(reader["Specification_ID"].ToString());
                        account.CustomerID = int.Parse(reader["Customer_ID"].ToString());
                        account.AccountTypeID = int.Parse(reader["Account_Type_ID "].ToString());
                        account.BankID = int.Parse(reader["Banking_ID"].ToString());
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return account;
            }
        }

        public Account SearchAccount(Account a)
        {
            return SearchAccount(a.ID);
        }
        public List<Account> ListAccounts()
        {
            var accountList = new List<Account>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListAccount";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var a = new Account();
                        a.ID = int.Parse(reader["Package_ID "].ToString());
                        a.ContactID = int.Parse(reader["Specification_ID"].ToString());
                        a.CustomerID = int.Parse(reader["Customer_ID"].ToString());
                        a.AccountTypeID = int.Parse(reader["Account_Type_ID "].ToString());
                        a.BankID = int.Parse(reader["Banking_ID"].ToString());



                        accountList.Add(a);
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

        // Gets a list of account on elements specified in the account object.
        public List<Account> SearchAccounts(Account a)
        {
            throw new NotImplementedException();
        }

        // Gets a list of account by values specified in the package object.
        public List<Account> SearchAccounts(Order o)
        {
            throw new NotImplementedException();
        }

        // Gets a list of accounts by the values speicifed in the account_type object.
        public List<Account> SearchAccounts(Account_Type at)
        {
            throw new NotImplementedException();
        }

        // Gets a list of accounts for a customer speicifed in the customer object.
        public List<Account> SearchAccounts(Customer c)
        {
            throw new NotImplementedException();
        }

        // Gets a list of accounts that have the contact speicifed in the contact object.
        public List<Account> SearchAccounts(Contact c)
        {
            throw new NotImplementedException();
        }

        // Gets a list of account that have the address specified in the address object.
        public List<Account> SearchAccounts(Address a)
        {
            throw new NotImplementedException();
        }

    }
}