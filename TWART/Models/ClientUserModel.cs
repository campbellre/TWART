﻿using System;
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


        public LoggedIn Login(ClientUser u)
        {
            var l = new LoggedIn();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ClientLoggingIn";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("UsersName", u.Username);
                    cmd.Parameters.AddWithValue("UserPass", u.Password);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        l.State = reader["login"].Equals(1);
                        l.UserID = (int)reader["UID"];
                        l.AccountID = int.Parse(reader["Account_ID"].ToString());
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }
            }

            return l;
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
                        cmd.Parameters.AddWithValue("pUsername", user.AccountID);
                        cmd.Parameters.AddWithValue("pPwd", user.Name);


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
                        cmd.Parameters.AddWithValue("pUsername", user.AccountID);
                        cmd.Parameters.AddWithValue("PPWD", user.Name);

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

                    cmd.Parameters.AddWithValue("PUID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user.UserID = int.Parse(reader["UID"].ToString());
                        user.AccountID = int.Parse(reader["Account_ID"].ToString());
                        user.Name = reader["Name"].ToString();
                        user.Username = reader["Username"].ToString();

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
                        user.Username = reader["Username"].ToString();

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


        public void ChangePassword(ClientUser u, String password)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "ChangeClientPassword";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("pUID", u.Username);
                        cmd.Parameters.AddWithValue("pPwd", password);

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


    }
}