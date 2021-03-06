﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class LoginModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public LoginModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateUser(User u)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewUserAccount";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PUsername", u.username);
                        cmd.Parameters.AddWithValue("PPWD", u.password);
                        cmd.Parameters.AddWithValue("EmployeeID", u.EmployeeID);

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

        public LoggedIn Login(User u)
        {
            var l = new LoggedIn();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "LoggingIn";
                    var cmd = new MySqlCommand(query, connect) {CommandType = CommandType.StoredProcedure};

                    cmd.Parameters.AddWithValue("UsersName", u.username);
                    cmd.Parameters.AddWithValue("UserPass", u.password);
                    
                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        l.State = reader["login"].Equals(1);
                        l.UserID = (int)reader["UID"];
                        l.AccessLevel = reader["AccessLevel"].ToString();
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

        public void ChangePassword(User u, String password)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "ChangePassword";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("pUID", u.username);
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

        // Main method to search users. 
        public User SearchUsers(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls the main search users method.
        public User SearchUsers(User u)
        {
            return SearchUsers(u.ID);
        }

        // For finding a user by their user name.
        public List<User> SearchUsers(String username)
        {
            throw new NotImplementedException();
        }

        public List<User> UsersList()
        {
            var lu = new List<User>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListUserAccount";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var u = new User();

                        u.ID = int.Parse(reader["UID"].ToString());
                        u.username = reader["Username"].ToString();
                        u.AccessLevel = reader["AccessLevel"].ToString();

                        lu.Add(u);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }
            }

            return lu;
        }

    }
}