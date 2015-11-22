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
    public class RoleModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public RoleModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateRole(Role r)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewRole";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("RoleTile", r.Title);
                        cmd.Parameters.AddWithValue("AccessLevel", r.AccessLevel);

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

        public void EditRole(Role r)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "EditRole";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("RoleID", r.Id);
                        cmd.Parameters.AddWithValue("RoleTitle", r.Title);
                        cmd.Parameters.AddWithValue("AccessLevel", r.AccessLevel);

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

        public void DeleteRole(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "DeleteRole";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("RoleID", ID);

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

        // The main method that gets a role from the database. 
        public Role SearchRoles(int ID)
        {
            var r = new Role();
            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetRole";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("RoleID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            r.Id = int.Parse(reader["Role_ID"].ToString());
                            r.Title = reader["Role_Title"].ToString();
                            r.AccessLevel = reader["Access_Level"].ToString();

                        }catch(Exception e){}
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return r;
            }
        }

        // Function calls main method for getting roles.
        public Role SearchRoles(Role r)
        {
            return SearchRoles(r.Id);
        }

        public List<Role> ListRoles()
        {
            var roleList = new List<Role>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListRole";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var role = new Role();

                        role.Id = (int)reader["Role_ID"];
                        role.Title = reader["Role_Title"].ToString();
                        role.AccessLevel = reader["Access_Level"].ToString();


                        roleList.Add(role);

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return roleList;
            }
        }



    }
}