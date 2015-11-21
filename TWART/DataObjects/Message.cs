using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Message
    {
        public int MessageID { get; set; }
        public String MessageBody { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
    }
}