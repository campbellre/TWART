using System;
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
        public Boolean NewEmployee(Employee em)
        {

            connect = new MySqlConnection(_connectionString);
            MySqlCommand empCommand = connect.CreateCommand();
            

            empCommand.CommandType = CommandType.Text;
            empCommand.CommandText = "INSERT INTO Employee " +
                                     "(Forenames, Surname, DOB, Contact_Number, Start_Date, Department_ID, Role_ID) " +
                                     "Values (?,?,?,?,?,?,?);";

            empCommand.Parameters.Add(new MySqlParameter("Forenames", em.Firstname));
            empCommand.Parameters.Add(new MySqlParameter("Surname", em.Lastname));
            empCommand.Parameters.Add(new MySqlParameter("DOB", em.DOB));
            empCommand.Parameters.Add(new MySqlParameter("Contact_Number", em.ContactNumber));
            empCommand.Parameters.Add(new MySqlParameter("Start_Date", em.Startdate));
            empCommand.Parameters.Add(new MySqlParameter("Department_ID", em.Dept));
            empCommand.Parameters.Add(new MySqlParameter("Role_ID", em.Role));


            connect.Open();

            empCommand.ExecuteNonQuery();

            connect.Close();;

            // TODO: This is Temporary.
            return true;
        }






    }
}