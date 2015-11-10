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


        public void CreateNewDepartment(Department department)
        {
            connect = new MySqlConnection(_connectionString);
            MySqlCommand createDepartment = connect.CreateCommand();

            createDepartment.CommandText = "INSERT INTO Department(Department_Title, Address_ID, Department_Head)" +
                                           "Values (?,?,?);";


            createDepartment.Parameters.Add(new MySqlParameter("Department_Title", department.Title));
            createDepartment.Parameters.Add(new MySqlParameter("Address_ID", department.Address));
            createDepartment.Parameters.Add(new MySqlParameter("Department_Head", department.Head));


            connect.Open();

            createDepartment.ExecuteNonQuery();

            connect.Close();

        }

        // Get department by id.
        // This is the impmented method others should call it. 
        public Department GetDepartment(int ID)
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
        public Department GetDepartment(Department department)
        {
            return this.GetDepartment(department.Id);
        }


    }
}