using System;
using System.Configuration;

namespace TWART.DataObjects
{
    public class Employee
    {
        private string dateFormat = "yyyy-MM-dd";

        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public DateTime DOB { get; set; }
        public String ContactNumber { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public int Dept { get; set; }
        public int Depot { get; set; }
        public int Role { get; set; }

        // Constructor for Employee class
        public Employee(int ID, String firstname, String lastname, DateTime DOB, String contactNumber, DateTime startDate, int dept, int depot, int role)
        {
            this.Id = ID;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.DOB = DOB;
            this.ContactNumber = contactNumber;
            this.Startdate = startDate;
            this.EndDate = EndDate;
            this.Dept = dept;
            this.Depot = depot;
            this.Role = role;
        }

        public String GetDOBString()
        {
            return this.DOB.ToString(dateFormat);
        }

        public String GetStartDateString()
        {
            return this.Startdate.ToString(dateFormat);
        }

        public String GetEndDateString()
        {
            return this.EndDate.ToString(dateFormat);
        }
    }
}