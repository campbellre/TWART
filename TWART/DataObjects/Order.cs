using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime Placed { get; set; }
        public DateTime Received { get; set; }
        public DateTime Delivered { get; set; }
        public int GoodsID { get; set; }
        public int DestinationAddressID { get; set; }
        public int SourceAddressID { get; set; }
        public int AccountID { get; set; }
        public DateTime DesiredDeliveryDate { get; set; }
        public Decimal TotalCost { get; set; }

    
    }
}