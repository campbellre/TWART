using System;
using System.Collections.Generic;
using System.Data;
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

        public int CreateTransaction(Transaction t)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewTransaction";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DateOfOrder", t.DateOfOrder);
                        cmd.Parameters.AddWithValue("PurchaceID", t.OrderID);
                        cmd.Parameters.AddWithValue("CustomerID", t.CustomerID);
                        cmd.Parameters.AddWithValue("BankingID", t.BankID);


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

        // Main method for getting an transaction.
        public Transaction SearchTransaction(int ID)
        {
            var transaction = new Transaction();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetTransaction";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("SaleTransactionID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transaction.ID = int.Parse(reader["Sale_Transaction_ID"].ToString());
                        transaction.DateOfOrder = DateTime.Parse(reader["Date_Of_Order"].ToString());
                        transaction.OrderID = int.Parse(reader["Purchase_ID"].ToString());
                        transaction.CustomerID = int.Parse(reader["Customer_ID"].ToString());
                        transaction.BankID = int.Parse(reader["Banking_ID"].ToString());

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return transaction;
            }
        }

        // Calls the main method for getting a transtion.
        public Transaction SearchTransaction(Transaction t)
        {
            return SearchTransaction(t.ID);
        }


        public List<Transaction> ListTransactions()
        {
            var transationList = new List<Transaction>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListTransaction";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var transaction = new Transaction();
                        transaction.ID = int.Parse(reader["Sale_Transaction_ID"].ToString());
                        transaction.DateOfOrder = DateTime.Parse(reader["Date_Of_Order"].ToString());
                        transaction.OrderID = int.Parse(reader["Purchase_ID"].ToString());
                        transaction.CustomerID = int.Parse(reader["Customer_ID"].ToString());
                        transaction.BankID = int.Parse(reader["Banking_ID"].ToString());

                        transationList.Add(transaction);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return transationList;
            }
        }

        // Returns Transations with the date of order specified by the datetime.
        public List<Transaction> SearchTransactions(DateTime date)
        {
            var transationList = new List<Transaction>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "SearchTransactionOneDate";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("SearchDate", date);
                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var transaction = new Transaction();
                        transaction.ID = int.Parse(reader["Sale_Transaction_ID"].ToString());
                        transaction.DateOfOrder = DateTime.Parse(reader["Date_Of_Order"].ToString());
                        transaction.OrderID = int.Parse(reader["Purchase_ID"].ToString());
                        transaction.CustomerID = int.Parse(reader["Customer_ID"].ToString());
                        transaction.BankID = int.Parse(reader["Banking_ID"].ToString());

                        transationList.Add(transaction);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return transationList;
            }
        }

        // Returns Transations between the start and end datetime objects.
        public List<Transaction> SearchTransactions(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // Finds Transactions with the specified details in the order object.
        public List<Transaction> SearchTransactions(Package p)
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