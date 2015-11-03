using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWART.Models
{
    public class Employee
    {
        private int Id { get; set; };
        private string Firstname { get; set; };
        private string Lastname { get; set; };
        private DateTime Dob { get; set; };
        private string ContactNumber { get; set; };
        private DateTime Startdate { get; set; };
        private DateTime EndDate { get; set; };
        private int Dept { get; set; };
        private int Depot { get; set; };
        private int Role { get; set; };


    }
}