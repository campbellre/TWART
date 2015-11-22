using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class SpecificationModel
    {
        private MySqlConnection connect;
        private string _connectionString;

        public SpecificationModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int NewSpecification(Specification s)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewPackageSpecification";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PWeight", s.Weight);
                        cmd.Parameters.AddWithValue("DeimensionHeight", s.Height);
                        cmd.Parameters.AddWithValue("DimensionWidth", s.Width);
                        cmd.Parameters.AddWithValue("DimensionLength", s.Length);

                        ret = int.Parse(cmd.ExecuteScalar().ToString());

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

        public void EditSpecification(Specification s)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "EditPackageSpecification";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("SpecificationID", s.ID);
                        cmd.Parameters.AddWithValue("PWeight", s.Weight);
                        cmd.Parameters.AddWithValue("DeimensionHeight", s.Height);
                        cmd.Parameters.AddWithValue("DimensionWidth", s.Width);
                        cmd.Parameters.AddWithValue("DimensionLength", s.Length);

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

        public void DeleteSpecification(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "DeletePackageSpecification";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };
                        
                        cmd.Parameters.AddWithValue("SpecificationID", ID);

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

        public List<Specification> GetSpecificationsList()
        {
            var specList = new List<Specification>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListPackageSpecification";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var s = new Specification();

                        s.ID = (int)reader["Specification_ID"];
                        s.Weight = (int)reader["Weight"];
                        s.Length = (int)reader["Dimension_Height"];
                        s.Width = (int)reader["Dimension_Width"];
                        s.Height = (int)reader["Dimension_Length"];


                        specList.Add(s);

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return specList;
            }
        }

        public Specification SearchSpecification(int ID)
        {
            var s = new Specification();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetPackageSpecification";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        s.ID = (int)reader["Specification_ID"];
                        s.Weight = (int)reader["Weight"];
                        s.Length = (int)reader["Dimension_Height"];
                        s.Width = (int)reader["Dimension_Width"];
                        s.Height = (int)reader["Dimension_Length"];

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return s;
            }
        }

        public Specification SearchSpecification(Specification s)
        {
            return  SearchSpecification(s.ID);
        }


    }
}