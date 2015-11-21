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
    public class ClientUserModel
    {

        private MySqlConnection connect;
        private string _connectionString;

        public ClientUserModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateClientUser(ClientUser user)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewClientUser";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("AccountID", user.AccountID);
                        cmd.Parameters.AddWithValue("pName", user.Name);


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

        public void EditClientUser(ClientUser user)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditClientUser";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PUID", user.UserID);
                        cmd.Parameters.AddWithValue("AccountID", user.AccountID);
                        cmd.Parameters.AddWithValue("pName", user.Name);
    


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

        public void DeleteClientUser(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteClientUser";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PUID", ID);

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
        public ClientUser SearchClientUser(int ID)
        {
            var user = new ClientUser();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetClientUser";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserID = int.Parse(reader["UID"].ToString());
                        user.AccountID = int.Parse(reader["Account_ID"].ToString());
                        user.Name = reader["Name"].ToString();

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return user;
            }
        }

        public ClientUser SearchClientUser(ClientUser user)
        {
            return SearchClientUser(user.UserID);
        }
        public List<ClientUser> ListAccounts()
        {
            var userList = new List<ClientUser>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListClientUser";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new ClientUser();
                        user.UserID = int.Parse(reader["UID "].ToString());
                        user.AccountID = int.Parse(reader["Account_ID"].ToString());
                        user.Name = reader["Name"].ToString();

                        userList.Add(user);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return userList;
            }
        }

    }
}