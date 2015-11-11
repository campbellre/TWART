using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.Controller;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class TransactionModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public TransactionModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public void CreateTransaction(Transaction t)
        {
            throw new NotImplementedException();
        }

        // Main method for getting an transaction.
        public Transaction SearchTransaction(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls the main method for getting a transtion.
        public Transaction SearchTransaction(Transaction t)
        {
            return SearchTransaction(t.ID);
        }

        // Returns Transations with the date of order specified by the datetime.
        public List<Transaction> SearchTransactions(DateTime date)
        {
            throw new NotImplementedException();
        }

        // Returns Transations between the start and end datetime objects.
        public List<Transaction> SearchTransactions(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // Finds Transactions with the specified details in the order object.
        public List<Transaction> SearchTransactions(Order o)
        {
            throw new NotImplementedException();
        }

        // Finds Transations with the specifed details in the customer object.
        public List<Transaction> SearchTransactions(Customer c)
        {
            throw new NotImplementedException();
        }


        // Finds Transactions with the specified details in the bank object.
        public List<Transaction> SearchTransactions(Bank b)
        {
            throw new NotImplementedException();
        }
    }
}