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
        public Package GetPackage(int ID)
        {
            throw new NotImplementedException();
        }

        // Calls the main method to get packages.
        public Package GetPackage(Package p)
        {
            return GetPackage(p.ID);
        }

        // This method is to get packages that match on elements included in the goods object.
        public List<Package> GetPackagesByGoods(Goods g)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the address object.
        // For a packages Destination Address.
        public List<Package> GetPackageByDestinationAddress(Address a)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the address object.
        // For a packages Source Address.
        public List<Package> GetPackageBySourceAddress(Address a)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that match on elements included in the trasport object.
        public List<Package> GetPackagesByTransport(Transport t)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that placed between the start and end dates.
        public List<Package> GetPackagesPlacesBetweenDate(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that we recived between the start and end dates.
        public List<Package> GetPackagesReceivedBetweenDate(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        // This method is to get packages that we delivered or are delivering between the start and end dates.
        public List<Package> GetPackagesDeliveredBetweenDate(DateTime start, DateTime end)
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