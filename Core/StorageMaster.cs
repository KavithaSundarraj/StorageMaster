using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core
{
    class StorageMaster
    {
        public List<Product> ProductPool;
        Product p;
        public List<Storage> StorageRegistry = new List<Storage>();
        Storage s;
        Vehicle selectedvehicle;

        public string AddProduct(string type, double price)
        {

            switch (type)
            {
                case "Gpu":
                    p = new Gpu(price);
                    break;
                case "Ram":
                    p = new Ram(price);
                    break;
                case "Harddrive":
                    p = new Harddrive(price);
                    break;
                case "SolidStateDrive":
                    p = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
                    //break;
            }
            ProductPool.Add(p);

            return $"Added {type} to pool";
        }

        // comment 
        public string RegisterStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    s = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    s = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    s = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");

            }
            StorageRegistry.Add(s);
            return $"Registered {name}";
        }

        public string Selectvehicle(string StorageName, int GarageSlot)
        {
            Storage s = StorageRegistry.Find(x => x.Name == StorageName);

            if (s == null)
            {
                throw new InvalidOperationException("Error: There is no such storage facility!");
            }
            else
            if (s.Garage[GarageSlot] != null)
            {
                selectedvehicle = s.Garage[GarageSlot];
            }
            else
            {
                throw new InvalidOperationException("Error: There is no vehicle in that garagespot!");
            }
            return $"Selected {selectedvehicle.Type}";
        }

        //The user adds items like "HardDrive, Ram, Ram"
        public string LoadVehicle(params string[] Productnames)
        {
            int productCount = Productnames.Length;
            int loadedProductsCount = 0;


            //For every item as parameter look through Productpool for item with same Type.
            for (int i = 0; i < productCount; i++)
            {
                switch (Productnames[i])
                {
                    case "Gpu":
                        Product Loadproduct = ProductPool.FindLast(x => x.Type == "Gpu");
                        if (Loadproduct == null)
                        {
                            throw new InvalidOperationException($"{Productnames[i]} is out of stock!");
                        }
                        else
                        {   //Need to add what happens if Loadproduct() throw exception
                            selectedvehicle.LoadProduct(Loadproduct);
                            ProductPool.Remove(Loadproduct);
                            loadedProductsCount++;
                        }
                        break;

                    case "HardDrive":
                        Loadproduct = ProductPool.FindLast(x => x.Type == "HardDrive");
                        if (Loadproduct == null)
                        {
                            throw new InvalidOperationException($"{Productnames[i]} is out of stock!");
                        }
                        else
                        {   //Need to add what happens if Loadproduct() throw exception
                            selectedvehicle.LoadProduct(Loadproduct);
                            ProductPool.Remove(Loadproduct);
                            loadedProductsCount++;
                        }
                        break;

                    case "Ram":
                        Loadproduct = ProductPool.FindLast(x => x.Type == "Ram");
                        if (Loadproduct == null)
                        {
                            throw new InvalidOperationException($"{Productnames[i]} is out of stock!");
                        }
                        else
                        {   //Need to add what happens if Loadproduct() throw exception
                            selectedvehicle.LoadProduct(Loadproduct);
                            ProductPool.Remove(Loadproduct);
                            loadedProductsCount++;
                        }
                        break;

                    case "SolidStateDrive":
                        Loadproduct = ProductPool.FindLast(x => x.Type == "SolidStateDrive");
                        if (Loadproduct == null)
                        {
                            throw new InvalidOperationException($"{Productnames[i]} is out of stock!");
                        }
                        else
                        {   //Need to add what happens if Loadproduct() throw exception
                            selectedvehicle.LoadProduct(Loadproduct);
                            ProductPool.Remove(Loadproduct);
                            loadedProductsCount++;
                        }
                        break;

                    default:
                        throw new InvalidOperationException("That's not a real product! What are you doing?!");
                }

            }
            return $"Loaded {loadedProductsCount}/{productCount} products into {selectedvehicle.Type}";
        }

        public string GetStorageStatus(string StorageName)
        {​​​
            Storage s = StorageRegistry.Find(x => x.Name == StorageName);
            /*The storage’s products are counted, grouped by name, 
            sorted by the product count (descending), then by product name (ascending).
            Then, every vehicle’s name in the garage is retrieved. If there is no vehicle in that garage, put “empty” in its garage slot.
The command produces two lines:
The first line is the stock format: “Stock ({0}/{1}): [{2}]”. The first parameter is the sum of the products’ weight, the second parameter is the storage’s capacity. The third parameter is the stock info, described above, separated by commas.
The second line is the garage format: “Garage: [{0}]”. The only parameter is the vehicle names (and empty garage slots), separated by a pipe character “|”. 

            Stock(2.7 / 10): [HardDrive(2), Gpu(1)]
        Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]*/
            int sumofproducts = s.products.Count;
            double sumofproductsweight = s.TotalWeightofAllProducts();
            int storagecapacity = s.Capacity;
            int GpuCount = 0, HardDriveCount = 0, RamCount = 0, SolidStateDriveCount = 0;
            foreach (Product p in s.products)
            {
                switch (p.Type)
                {
                    case "Gpu":
                        GpuCount++;
                        break;
                    case "HardDrive":
                        HardDriveCount++;
                        break;
                    case "Ram":
                        RamCount++;
                        break;
                    case "SolidStateDrive":
                        SolidStateDriveCount++;
                        break;
                }
            }

            string vehicleType = "";
            for (int i = 0; i < s.GarageSlots; i++)
            {
                if (s.Garage[i] == null)
                {
                    vehicleType += "empty";
                }
                else
                {
                    vehicleType += s.GetType().ToString();
                }
            }

            return $"Stock ({sumofproductsweight}/{storagecapacity}):[Gpu {GpuCount}, HardDrive {HardDriveCount}, Ram {RamCount}, SolidStateDrive {SolidStateDriveCount}] \n Garage:{vehicleType}";
            //return $"{garage[0].Type}|{garage[1].Type}|{garage[2].Type}"



            /*List<Product> count = LoadProduct();
            int count = 0;
            var productcount = s.GetStorageStatus(StorageName).GroupBy(p => p.name).ToList;
            var productcountInDescOrder = storage.OrderByDescending(p => p.productcount);
            var StoragenameInAscenOrder = Storage.OrderByAscending(s => s.StorageName);*/

        }
    }
}
