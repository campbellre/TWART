﻿using System;
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
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "EditEmployee";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("EmployeeID", em.Id);
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

        public void DeleteEmployee(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "DeleteEmployee";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("EmployeeID", ID);

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

        public List<Employee> GetEmployeesList()
        {
            var empList = new List<Employee>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListEmployee";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var e = new Employee();

                        e.Id = (int)reader["Employee_ID"];
                        e.Firstname = reader["Forenames"].ToString();
                        e.Lastname = reader["Surname"].ToString();
                        e.DOB = DateTime.Parse(reader["DOB"].ToString());
                        e.ContactNumber = reader["Contact_Number"].ToString();
                        e.Startdate = DateTime.Parse(reader["Start_Date"].ToString());
                        e.EndDate = DateTime.Parse(reader["End_Date"].ToString());
                        e.Dept = (int)reader["Department_ID"];
                        e.Depot = (int)reader["Depot_ID"];
                        e.Role = (int)reader["Role_ID"];


                        empList.Add(e);

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return empList;
            }
        }

        public Employee SearchEmployee(int ID)
        {
            var emp = new Employee();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetEmployee";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("EmployeID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        emp.Id = (int)reader["Employee_ID"];
                        emp.Firstname = reader["Forenames"].ToString();
                        emp.Lastname = reader["Surname"].ToString();
                        emp.DOB = DateTime.Parse(reader["DOB"].ToString());
                        emp.ContactNumber = reader["Contact_Number"].ToString();
                        emp.Startdate = DateTime.Parse(reader["Start_Date"].ToString());
                        emp.EndDate = DateTime.Parse(reader["End_Date"].ToString());
                        emp.Dept = (int)reader["Department_ID"];
                        emp.Depot = (int)reader["Depot_ID"];
                        emp.Role = (int)reader["Role_ID"];
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return emp;
            }
        }

        public Employee SearchEmployee(Employee em)
        {
            return SearchEmployee(em.Id);
        }



    }
}