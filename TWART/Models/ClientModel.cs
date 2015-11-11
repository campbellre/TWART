using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.Properties;

namespace TWART.Models
{
    public class ClientModel
    {
        private MySqlConnection connect;
        private string _connectionString;
        
        public ClientModel()
        {
            _connectionString = Resource1.ConnectionString;
        }




    }
}