using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void EditAccount(Account a)
        {
            throw new NotImplementedException();

        }

        // The main method to get a user account.
        public Account GetAccount(int ID)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(Account a)
        {
            throw new NotImplementedException();
        }
        public List<Account> ListAccounts()
        {
            throw new NotImplementedException();
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