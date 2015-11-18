using System;
using System.Collections.Generic;
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

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersList()
        {
            throw new NotImplementedException();
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