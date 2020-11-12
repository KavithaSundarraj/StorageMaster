using StorageMaster.Core;
using StorageMaster.IO;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {

             /*StorageMasters s = new StorageMasters();
             Console.WriteLine(s.RegisterStorage("DistributionCenter", "SofiaDistribution"));
             Console.WriteLine(s.RegisterStorage("DistributionCenter", "AmazonWarehouse"));
             Console.WriteLine(s.AddProduct("Gpu", 1200));
             Console.WriteLine(s.AddProduct("Gpu", 1200));
 //          Console.WriteLine(s.SelectVehicle("SofiaDistribution", 0));  // Incorrect!!! No Slot 0 -- so it was not loading anything!!!
             Console.WriteLine(s.SelectVehicle("SofiaDistribution", 1));
             Console.WriteLine(s.LoadVehicle("Gpu", "Gpu"));
             Console.WriteLine(s.SendVehicleTo("SofiaDistribution", 1, "AmazonWarehouse"));
 //          Console.WriteLine(s.UnloadVehicle("SofiaDistribution", 4));  // Incorrect!!! Vehicle has been transferred to AmazonWarehouse;
             Console.WriteLine(s.UnloadVehicle("AmazonWarehouse", 4));
             Console.WriteLine(s.GetStorageStatus("SofiaDistribution"));
             Console.WriteLine(s.GetStorageStatus("AmazonWarehouse"));      
             Console.WriteLine(s.GetSummary());
             */

            ConsoleDataReader CDR = new ConsoleDataReader();
            CDR.getinput();
        }
    }
}
