using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;

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
            List<Department> deptList = new List<Department>(); 
            connect = new MySqlConnection(_connectionString);
            MySqlCommand empCommand = connect.CreateCommand();

            empCommand.CommandText = "SELECT Department_ID, Department_Title, Address_ID, Department_Head" +
                                     "From Department;";

            MySqlDataReader reader;

            reader = empCommand.ExecuteReader();

            foreach (DataRow deptColumn in reader)
            {
         
                deptList.Add(new Department(deptColumn["Department_ID"], deptColumn["Department_Title"],deptColumn["Address_ID"], deptColumn["Department_Head"]));
            }




        }

    }
}