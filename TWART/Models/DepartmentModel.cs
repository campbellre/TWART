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
            // TODO: Correct to use usings.

            List<Department> deptList = new List<Department>(); 
            connect = new MySqlConnection(_connectionString);
            MySqlCommand empCommand = connect.CreateCommand();

            empCommand.CommandText = "SELECT Department_ID, Department_Title, Address_ID, Department_Head" +
                                     "From Department;";

            MySqlDataReader reader;
            
            connect.Open();
            
            reader = empCommand.ExecuteReader();

            foreach (DataRow deptColumn in reader)
            {
         
                deptList.Add(new Department(deptColumn["Department_ID"], deptColumn["Department_Title"],deptColumn["Address_ID"], deptColumn["Department_Head"]));
            }

            reader.Close();

            connect.Close();

            return deptList;

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

                        cmd.Parameters.AddWithValue("DepartmentID",d.Id)
                        cmd.Parameters.AddWithValue("DepartmentTitle", d.Title);
                        cmd.Parameters.AddWithValue("AddressID", d.Address);
                        cmd.Parameters.AddWithValue("DepartmentHead", d.Head);

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

                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        connect.Close();
                    }
                }
            }
        }

        // Get department by id.
        // This is the impmented method others should call it. 
        public Department SearchDepartment(int ID)
        {
            Department returnDepartment = null;

            connect = new MySqlConnection(_connectionString);
            MySqlCommand getByIdDepartment = connect.CreateCommand();

            getByIdDepartment.CommandText = "SELECT Department_ID, Department_Title, Address_Id, Department_Head " +
                                            "From Department " +
                                            "WHERE Department_ID = ?";
            getByIdDepartment.Parameters.Add(new MySqlParameter("Department_ID", ID));

            MySqlDataReader reader;

            connect.Open();

            reader = getByIdDepartment.ExecuteReader();

            if (reader.NextResult())
            {
                returnDepartment = new Department(reader["Department_ID"],
                    reader["Department_Title"],
                    reader["Address_ID"],
                    reader["Department_Head"]);
            }

            connect.Close();

            return returnDepartment;

        }


        // Overload to allow getting department be either id or a department object. 
        public Department SearchDepartment(Department department)
        {
            return this.SearchDepartment(department.Id);
        }


    }
}