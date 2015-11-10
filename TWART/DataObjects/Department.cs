using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.DataObjects
{
    public class Department
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Address { get; set; }
        public int Head { get; set; }

        public Department(int id, String title, int address, int head)
        {
            Id = id;
            Title = title;
            Address = address;
            Head = head;
        }

        public Department() { }

        public Department(object id, object title, object address, object head)
        {
            Id = (int) id;
            Title = title.ToString();
            Address = (int) address;
            Head = (int) head;
        }
    }
}