using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWART.DataObjects;
using TWART.Models;

namespace TWART.Handlers
{
    // Allows creation of goods
    public class GoodsHandler
    {
        // Constructor
        public GoodsHandler()
        { }

        // Create goods
        public int create(String name, String handling)
        {
            // Establishes model
            GoodsModel goodsModel = new GoodsModel();

            // Holds the new goods
            Goods newGoods = new Goods();

            // Stored details for the goods
            newGoods.Name = name;
            newGoods.HandlingRequirments = handling;

            // Adds the object to the database
            int goodsID = goodsModel.CreateGoods(newGoods);

            // Return goodsID
            return goodsID;
        }
    }
}