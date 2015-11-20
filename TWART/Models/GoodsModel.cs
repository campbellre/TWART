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
    public class GoodsModel
    {
         private MySqlConnection connect;
        private string _connectionString;

        public GoodsModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        public int CreateGoods(Goods g)
        {
            int ret = 0;
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewGoods";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("ItemName", g.Name);
                        cmd.Parameters.AddWithValue("TransportationID", g.Name);
                        cmd.Parameters.AddWithValue("DesiredDeliveryDate", g.Name);
                        cmd.Parameters.AddWithValue("HandlingRequirements", g.Name);



                        ret = (int)cmd.ExecuteScalar();

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

        public void EditGoods(Goods g)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditGoods";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("GoodsID", g.ID);
                        cmd.Parameters.AddWithValue("TransportationID", g.TransportID);
                        cmd.Parameters.AddWithValue("DesiredDeliveryDate", g.DesiredDeliveryDate);
                        cmd.Parameters.AddWithValue("HandlingRequirements", g.HandlingRequirments);

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

        public void DeleteGoods(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteGoods";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("GoodsID", ID);

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

        // The main method to get a user account.
        public Goods SearchGoods(int ID)
        {
            var goods = new Goods();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "GetGoods";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        goods.ID = int.Parse(reader["Goods_ID"].ToString());
                        goods.Name = reader["Item_Name"].ToString();
                        goods.TransportID = int.Parse(reader["Transportation_ID"].ToString());
                        goods.DesiredDeliveryDate = DateTime.Parse(reader["Desired_Delivery_Date"].ToString());
                        goods.HandlingRequirments = reader["Handling_requirements"].ToString();


                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return goods;
            }
        }

        public Goods SearchGoodst(Goods a)
        {
            return SearchGoods(a.ID);
        }
        public List<Goods> ListGoods()
        {
            var goodsList = new List<Goods>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListGoods";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var goods = new Goods();
                        goods.ID = int.Parse(reader["Goods_ID "].ToString());
                        goods.Name = reader["Item_Name"].ToString();
                        goods.HandlingRequirments = reader["Handling_requirements"].ToString();
                        goods.DesiredDeliveryDate = DateTime.Parse(reader["Desired_Delivery_Date"].ToString());
                        goods.TransportID = int.Parse(reader["Transportation_ID "].ToString());

                        goodsList.Add(goods);
                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return goodsList;
            }
        }

    }
}