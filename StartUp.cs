using StorageMaster.Core;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            /*
            Van v = new Van();

            Console.WriteLine("This is a test!!!");
            Console.WriteLine("Object type is : {0}", v.GetType().Name);
            Console.ReadLine();

            RegisterStorage DistributionCenter SofiaDistribution
RegisterStorage Warehouse AmazonWarehouse
AddProduct Gpu 1200
AddProduct SolidStateDrive 205
AddProduct HardDrive 70
AddProduct HardDrive 120*/
            

                        StorageMasters s = new StorageMasters();
           Console.WriteLine(s.RegisterStorage("DistributionCenter", "SofiaDistribution"));
            Console.WriteLine(s.RegisterStorage("DistributionCenter", "AmazonWarehouse"));
            Console.WriteLine(s.AddProduct("Gpu", 1200));
            Console.WriteLine(s.AddProduct("Gpu", 1200));
            Console.WriteLine(s.SelectVehicle("SofiaDistribution", 0));
            Console.WriteLine(s.LoadVehicle("Gpu", "Gpu"));
            Console.WriteLine(s.SendVehicleTo("SofiaDistribution", 1, "AmazonWarehouse"));
            //Console.WriteLine(s.UnloadVehicle("SofiaDistribution", 1));
            Console.WriteLine(s.GetStorageStatus("AmazonWarehouse"));
            Console.WriteLine(s.GetStorageStatus("SofiaDistribution"));
            Console.WriteLine(s.GetSummary());

        }
    }
}
