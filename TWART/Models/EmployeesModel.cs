using System;
using System.Resources;
using MySql.Data.MySqlClient;
using TWART.DataObjects;

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
        public Boolean NewEmployee(Employee em)
        {

            connect = new MySqlConnection(_connectionString);
            MySqlCommand empCommand = connect.CreateCommand();

            empCommand.CommandText = @"Insert into Employee " +
                                     "(Forenames, Surname, DOB, Contact_Number, Start_Date, Department_ID, Role_ID) " +
                                     "Values" +
                                     "(" +
                                     "'" + em.Firstname + "'," +
                                     "'" + em.Lastname + "'," +
                                     "'" + em.GetDOBString()+ "'," +
                                     "'" + em.ContactNumber + "'," +
                                     "'" + em.GetStartDateString() + "'," +
                                           em.Dept + "," +
                                           em.Role +
                                     "); ";

            connect.Open();

            empCommand.ExecuteNonQuery();

            // TODO: This is Temporary.
            return true;
        }



    }
}