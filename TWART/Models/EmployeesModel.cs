using System;
using System.Collections.Generic;
using System.Data;
using System.Resources;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{ 
    public class EmployeesModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public EmployeesModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        // Function to create a new employee in the database.
        public int NewEmployee(Employee em)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewEmployee";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PForename", em.Firstname);
                        cmd.Parameters.AddWithValue("PSurname", em.Lastname);
                        cmd.Parameters.AddWithValue("PDOB", em.DOB);
                        cmd.Parameters.AddWithValue("ContactNumber", em.ContactNumber);
                        cmd.Parameters.AddWithValue("StartDate", em.Startdate);
                        cmd.Parameters.AddWithValue("EndDate", em.EndDate);
                        cmd.Parameters.AddWithValue("DepartmentID", em.Dept);
                        cmd.Parameters.AddWithValue("DepotID", em.Depot);
                        cmd.Parameters.AddWithValue("RoleID", em.Role);

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

        public void EditEmployee(Employee em)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesList()
        {
            throw new NotImplementedException();
        }

        public Employee SearchEmployee(int ID)
        {
            throw new NotImplementedException();
        }

        public Employee SearchEmployee(Employee em)
        {
            SearchEmployee(em.Id);
        }



    }
}