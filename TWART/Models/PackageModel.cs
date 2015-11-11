using System;
using System.Collections.Generic;
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

        public void CreatePackage()
        {
            throw new NotImplementedException();
        }

        public List<Package> GetPackagesList()
        {
            throw new NotImplementedException();
        }

        // This is the main method to get a package from the packages ID within the databse.
        public Package SearchPackage(int ID)
        {
            throw new NotImplementedException();
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
        public List<Package> SearchPackage(Transport t)
        {
            throw new NotImplementedException();
        }

        // This method is to get all packages with a placed, received or delivered date
        // between the start and end dates.
        public List<Package> SearchPackage(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // This method is to get allow packages with either a placed, recieved or delivered date
        // between the start and end dates. With the PackageDateType specifing whether to search
        // on the placed, recived or deliverd date. 
        public List<Package> SearchPackage(DateTime start, DateTime end, PackageDateType type)
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