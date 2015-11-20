using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class TransportModel
    {
        
        private MySqlConnection connect;
        private string _connectionString;

        public TransportModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateAccount(Transport t)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewTransportation";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("TransportationType", t.Type);


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

        public void EditAccount(Transport t)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditTransportation";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("TransportationID", t.ID);
                        cmd.Parameters.AddWithValue("TransportationType", t.Type);


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
                        string query = "DeleteTransportation";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("TransportationID", ID);

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
        public Transport SearchAccount(int ID)
        {
            var transport = new Transport();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetTransportation";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        transport.ID = int.Parse(reader["Transportation_ID"].ToString());
                        transport.Type = reader["Transportation_Type"].ToString();

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return transport;
            }
        }

        public Transport SearchAccount(Transport a)
        {
            return SearchAccount(a.ID);
        }
        public List<Transport> ListAccounts()
        {
            var transportList = new List<Transport>();

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
                        var transport = new Transport();
                        transport.ID = int.Parse(reader["Transportation_ID "].ToString());
                        transport.Type = reader["Transportation_Type"].ToString();

                        transportList.Add(transport);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return transportList;
            }
        }

    }
}