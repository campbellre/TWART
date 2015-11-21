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
    public class DepotModel
    {

        private MySqlConnection connect;
        private string _connectionString;

        public DepotModel()
        {
            _connectionString = Resource1.ConnectionString;
        }


        public int CreateDepot(Depot d)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "NewRole";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepotName", d.DepotName);
                        cmd.Parameters.AddWithValue("FloorSpace", d.FloorSpace);
                        cmd.Parameters.AddWithValue("NumOfVehicles", d.NumVehicles);
                        cmd.Parameters.AddWithValue("AddressID", d.Address);
                        cmd.Parameters.AddWithValue("DepotManager", d.ManagerID);


                        connect.Open();

                        ret = int.Parse(cmd.ExecuteScalar().ToString());

                        transaction.Commit();
                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
            return ret;
        }

        public void EditDepot(Depot d)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "EditRole";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepotID", d.ID);
                        cmd.Parameters.AddWithValue("DepotName", d.DepotName);
                        cmd.Parameters.AddWithValue("FloorSpace", d.FloorSpace);
                        cmd.Parameters.AddWithValue("NumOfVehicles", d.NumVehicles);
                        cmd.Parameters.AddWithValue("AddressID", d.Address);
                        cmd.Parameters.AddWithValue("DepotManager", d.ManagerID);


                        connect.Open();

                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
        }

        public void DeleteDepot(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {

                    try
                    {
                        string query = "DeleteDepot";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("DepotID", ID);


                        connect.Open();

                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        connect.Close();
                    }
                    catch (InvalidOperationException ioException)
                    {
                        transaction.Rollback();
                        connect.Close();
                    }
                }
            }
        }

        public List<Depot> ListDepots()
        {
            var depotList = new List<Depot>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListDepot";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var depot = new Depot();

                        depot.ID = (int) reader["Depot_ID"];
                        depot.DepotName = reader["Depot_Name"].ToString();
                        depot.FloorSpace = (double)reader["Floor_space"];
                        depot.NumVehicles = (int)reader["NumVehicles"];
                        depot.AddressID = (int)reader["Address_ID"];
                        depot.ManagerID = (int) reader["Depot_Manager"];



                        depotList.Add(depot);

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return depotList;
            }
        }

        public Depot SearchDepot(int ID)
        {
            var depot = new Depot();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetDepot";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("DepotID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            depot.ID = (int)reader["Depot_ID"];
                        }
                        catch (Exception) { }
                        depot.DepotName = reader["Depot_Name"].ToString();
                        depot.FloorSpace = (double)reader["Floor_space"];
                        depot.NumVehicles = (int)reader["NumVehicles"];
                        try
                        {
                            depot.AddressID = (int)reader["Address_ID"];
                        }
                        catch (Exception) { }
                        depot.ManagerID = (int)reader["Depot_Manager"];
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return depot;
            }
        }

        public Depot SearchDepot(Depot d)
        {
            return SearchDepot(d.ID);
        }
    }
}