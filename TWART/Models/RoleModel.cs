using System;
using System.Collections.Generic;
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

        public void CreateRole(Role r)
        {
            throw new NotImplementedException();
        }

        // The main method that gets a role from the database. 
        public Role SearchRoles(int ID)
        {
            throw new NotImplementedException();
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