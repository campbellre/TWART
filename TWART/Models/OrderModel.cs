﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TWART.DataObjects;
using TWART.Properties;

namespace TWART.Models
{
    public class OrderModel
    {
        private MySqlConnection connect;
        private string _connectionString;
        public OrderModel()
        {
            _connectionString = Resource1.ConnectionString;
        }

        // This may be broken 
        public void CreateOrder(Order o)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "NewOrder";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("OrderStatus", o.OrderStatus);
                        cmd.Parameters.AddWithValue("DatePlaced", o.Placed);
                        cmd.Parameters.AddWithValue("GoodsID", o.GoodsID);
                        cmd.Parameters.AddWithValue("DestinationAddressID", o.DestinationAddressID);
                        cmd.Parameters.AddWithValue("SourceAddressID", o.SourceAddressID);
                        cmd.Parameters.AddWithValue("AccountID", o.AccountID);

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

        public void EditOrder(Order o)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "EditOrder";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("OrderID", o.ID);
                        cmd.Parameters.AddWithValue("OrderStatus", o.OrderStatus);
                        cmd.Parameters.AddWithValue("DatePlaced", o.Placed);
                        cmd.Parameters.AddWithValue("DateReceived", o.Received);
                        cmd.Parameters.AddWithValue("DateDelivered", o.Delivered);
                        cmd.Parameters.AddWithValue("GoodsID", o.GoodsID);
                        cmd.Parameters.AddWithValue("DestinationAddressID", o.DestinationAddressID);
                        cmd.Parameters.AddWithValue("SourceAddressID", o.SourceAddressID);
                        cmd.Parameters.AddWithValue("AccountID", o.AccountID);

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

        public void DeleteOrder(int ID)
        {
            using (connect = new MySqlConnection(_connectionString))
            {
                connect.Open();
                using (MySqlTransaction transaction = connect.BeginTransaction())
                {
                    try
                    {
                        string query = "DeleteOrder";
                        var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.AddWithValue("OrderID", ID);
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

        public List<Order> GetOrdersList()
        {
            var orderList = new List<Order>();

            using (connect = new MySqlConnection(_connectionString))
            {
                try
                {
                    string query = "ListOrder";
                    var cmd = new MySqlCommand(query, connect) { CommandType = CommandType.StoredProcedure };

                    connect.Open();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var o = new Order();
                        // TODO : FIX THIS

                    }

                    connect.Close();
                }
                catch (InvalidOperationException ioException)
                {
                    connect.Close();
                }

                return orderList;
            }
        }

        // This is the main method to get a order from the order ID within the databse.
        public Order SearchOrder(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls the main method to get order.
        public Order SearchOrder(Order p)
        {
            return SearchOrder(p.ID);
        }

        // This method is to get order that match on elements included in the goods object.
        public List<Order> SearchOrder(Goods g)
        {
            throw new NotImplementedException();
        }

        // This method is to get orders that match on elements included in the address object.
        // Searches for orders with both source and destination addresses.
        public List<Order> SearchOrder(Address a)
        {
            throw new NotImplementedException();
        }

        // This method is to get orders that match on elements included in the address object.
        // Will match on items being source of destination, specified by AddressType enum.
        public List<Order> SearchOrder(Address a, AddressType type)
        {
            throw new NotImplementedException();
        }

        // This method is to get orders that match on elements included in the trasport object.
        public List<Order> SearchOrder(Transport t)
        {
            throw new NotImplementedException();
        }

        // This method is to get all orders with a placed, received or delivered date
        // between the start and end dates.
        public List<Order> SearchOrder(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // This method is to get allow orders with either a placed, recieved or delivered date
        // between the start and end dates. With the OrderDateType specifing whether to search
        // on the placed, recived or deliverd date. 
        public List<Order> SearchOrder(DateTime start, DateTime end, OrderDateType type)
        {
            throw new NotImplementedException();
        }

        // This method is to add the start of a delay to a order.
        public void AddOrderDelay(int ID, DateTime start)
        {
            throw new NotImplementedException();
        }

        // This method is to add the end of a delay to a order.
        public void FinishOrderDelay(int ID, DateTime end)
        {
            throw  new NotImplementedException();
        }

    }
}