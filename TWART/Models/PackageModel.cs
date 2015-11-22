using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class PackageModel
    {
        private MySqlConnection connect;
        private string _connectionString;
        public PackageModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreatePackage(Package p)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewPackage";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("SpecificationID", p.Specification);
                        cmd.Parameters.AddWithValue("GoodsID", p.Goods);

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

        public void EditPackage(Package p)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditPackage";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PackageID", p.ID);
                        cmd.Parameters.AddWithValue("SpecificationID", p.Specification);
                        cmd.Parameters.AddWithValue("GoodsID", p.Goods);

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

        public void DeletePackage(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeletePackage";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("PackageID", ID);

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

        public List<Package> GetPackagesList()
        {
            var packageList = new List<Package>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListPackage";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var p = new Package();
                        p.ID = int.Parse(reader["Package_ID "].ToString());
                        p.SpecificationID = int.Parse(reader["Specification_ID"].ToString());
                        p.GoodsID = int.Parse(reader["Goods_ID"].ToString());


                        packageList.Add(p);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return packageList;
            }
        }

        // This is the main method to get a package from the packages ID within the databse.
        public Package SearchPackage(int ID)
        {

            var p = new Package();
            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListPackage";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("PackageID", ID);

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        p.ID = int.Parse(reader["Package_ID "].ToString());
                        p.SpecificationID = int.Parse(reader["Specification_ID"].ToString());
                        p.GoodsID = int.Parse(reader["Goods_ID"].ToString());

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return p;
            }
        }

        // Calls the main method to get packages.
        public Package SearchPackage(Package p)
        {
            return SearchPackage(p.ID);
        }

        // This method is to get packages that match on elements included in the goods object.
        public List<Package> SearchPackage(Goods g)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the address object.
        // Searches for packages with both source and destination addresses.
        public List<Package> SearchPackage(Address a)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the address object.
        // Will match on items being source of destination, specified by AddressType enum.
        public List<Package> SearchPackage(Address a, AddressType type)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the trasport object.

        // This method is to get all packages with a placed, received or delivered date
        // between the start and end dates.
        public List<Package> SearchPackage(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // This method is to get allow packages with either a placed, recieved or delivered date
        // between the start and end dates. With the PackageDateType specifing whether to search
        // on the placed, recived or deliverd date. 
        public List<Package> SearchPackage(DateTime start, DateTime end, OrderDateType type)
        {
            throw new NotImplementedException();
        }

        // This method is to add the start of a delay to a package.
        public void AddPackageDelay(int ID, DateTime start)
        {
            throw new NotImplementedException();
        }

        // This method is to add the end of a delay to a package.
        public void FinishPackageDelay(int ID, DateTime end)
        {
            throw  new NotImplementedException();
        }

    }
}