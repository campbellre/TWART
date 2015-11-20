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


                        connect.Open();

                        ret = (int)cmd.ExecuteScalar();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        connect.Close();
                    }
                }
            }
            return ret;
        }

        public void EditRole(Role r)
        {
            int ret = 0;
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
                        cmd.Parameters.AddWithValue("RoleTile", r.Title);


                        connect.Open();

                        cmd.ExecuteNonQuery();

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
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
                        r.Id = int.Parse(reader["Role_ID "].ToString());
                        r.Title = reader["Role_Title"].ToString();

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return p;
            }
        }

        // Function calls main method for getting roles.
        public Role SearchRoles(Role r)
        {
            return SearchRoles(r.Id);
        }

        public List<Role> GetRolesList()
        {
            throw new NotImplementedException();
        }



    }
}