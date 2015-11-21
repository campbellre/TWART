using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Resources;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Properties;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class DepartmentModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public DepartmentModel()
        {
            _connectionString = Resource1.ConnectionString;
        }


        public List<Department> GetDepartmentsList()
        {
            var departmentList = new List<Department>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListDepartment";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };


                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        var d = new Department();
                        d.Id = (int)reader["Department_ID"];
                        d.Title = reader["Department_Title"].ToString();
                        d.AddressID = (int)reader["Address_ID"];
                        d.DHeadID = (int)reader["Department_Head"];


                        departmentList.Add(d);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return departmentList;
            }
        }


        public int CreateNewDepartment(Department department)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewDepartment";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepartmentTitle", department.Title);
                        cmd.Parameters.AddWithValue("AddressID", department.Address);
                        cmd.Parameters.AddWithValue("DepartmentHead", department.Head);

                        connect.Open();

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

        public void EditDepartment(Department d)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "EditDepartment";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepartmentID", d.Id);
                        cmd.Parameters.AddWithValue("DepartmentTitle", d.Title);
                        cmd.Parameters.AddWithValue("AddressID", d.Address);
                        cmd.Parameters.AddWithValue("DepartmentHead", d.Head);

                        connect.Open();

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

        public void DeleteDepartment(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "DeleteDepartment";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepartmentID", ID);


                        connect.Open();

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

        // Get department by id.
        // This is the impmented method others should call it. 
        public Department SearchDepartment(int ID)
        {
            var department = new Department();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetDepartment";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("DepartmentID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            department.Id = (int)reader["Department_ID"];
                            department.Title = reader["Department_Title"].ToString();
                            department.AddressID = (int)reader["Address_ID"];
                            department.DHeadID = (int)reader["Department_Head"];
                        }
                        catch (Exception) { }

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return department;
            }

        }


        // Overload to allow getting department be either id or a department object. 
        public Department SearchDepartment(Department department)
        {
            return this.SearchDepartment(department.Id);
        }


    }
}