using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class LoginModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public LoginModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public void CreateUser(User u)
        {
            throw new NotImplementedException();
        }

        public LoggedIn Login(User u)
        {
            throw new NotImplementedException();
        }

        public void ChangePasswork(User u, String password)
        {
            throw new NotImplementedException();
        }

        // Main method to search users. 
        public User SearchUsers(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls the main search users method.
        public User SearchUsers(User u)
        {
            return SearchUsers(u.ID);
        }

        // For finding a user by their user name.
        public List<User> SearchUsers(String username)
        {
            throw new NotImplementedException();
        }

    }
}