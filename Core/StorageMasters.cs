using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMasters
    {
        public List<Product> ProductPool= new List<Product>();
        Product p;
        public List<Storage> StorageRegistry = new List<Storage>();
        Storage s;
        Vehicle selectedvehicle;
        public ProductFactory productFactory = new ProductFactory();
        public StorageFactory storageFactory = new StorageFactory();

        public string AddProduct(string type, double price)
        {
            try
            {
                p = this.productFactory.CreateProduct(type, price);
                ProductPool.Add(p);
                return $"Added {type} to pool";
            }
            catch (Exception ex) { return ex.Message; }
        }

        // comment 
        public string RegisterStorage(string type, string name)
        {
            try
            {
                s = storageFactory.CreateStorage(type, name);
                StorageRegistry.Add(s);
                return $"Registered {name}";
            }
            catch(Exception ex) {return ex.Message ;}
        }

        public string SelectVehicle(string StorageName, int GarageSlot)
        {
            try
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
            catch(InvalidOperationException ex) {return ex.Message;}
        }

        public string LoadVehicle(params string[] Productnames)
        {
            int productCount = Productnames.Length;
            int loadedProductsCount = 0;
            try 
            {
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
                            {   
                                selectedvehicle.LoadProduct(Loadproduct);
                                ProductPool.Remove(Loadproduct);
                                loadedProductsCount++;
                            }
                            break;

                        case "Harddrive":
                            Loadproduct = ProductPool.FindLast(x => x.Type == "Harddrive");
                            if (Loadproduct == null)
                            {
                                throw new InvalidOperationException($"{Productnames[i]} is out of stock!");
                            }
                            else
                            {   
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
                            {   
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
                            {   
                                selectedvehicle.LoadProduct(Loadproduct);
                                ProductPool.Remove(Loadproduct);
                                loadedProductsCount++;
                            }
                            break;

                        default:
                            throw new InvalidOperationException("ERROR: That's not a real product!");
                    }
                }
            }
            catch(Exception ex) { return ex.Message; }
            return $"Loaded {loadedProductsCount}/{productCount} products into {selectedvehicle.Type}";
        }
        public string GetStorageStatus(string StorageName)
        {
            Storage s = StorageRegistry.Find(x => x.Name == StorageName);
            /*
             * The storage’s products are counted, grouped by name, 
                sorted by the product count (descending), then by product name (ascending).
                Then, every vehicle’s name in the garage is retrieved. If there is no vehicle in that garage, put “empty” in its garage slot.
                The command produces two lines:
                The first line is the stock format: “Stock ({0}/{1}): [{2}]”. The first parameter is the sum of the products’ weight, the second parameter is the storage’s capacity. The third parameter is the stock info, described above, separated by commas.
                The second line is the garage format: “Garage: [{0}]”. The only parameter is the vehicle names (and empty garage slots), separated by a pipe character “|”. 
                            Stock(2.7 / 10): [HardDrive(2), Gpu(1)]
                Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]
            */
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
                    vehicleType += "empty"+"|";
                }
                else
                {
                    vehicleType += s.Garage[i].GetType().Name.ToString()+" | ";
                }
            }
            return $"Stock ({sumofproductsweight}/{storagecapacity}):[Gpu {GpuCount}, HardDrive {HardDriveCount}, Ram {RamCount}, SolidStateDrive {SolidStateDriveCount}] \n Garage:{vehicleType}";

            /*List<Product> count = LoadProduct();
            int count = 0;
            var productcount = s.GetStorageStatus(StorageName).GroupBy(p => p.name).ToList;
            var productcountInDescOrder = storage.OrderByDescending(p => p.productcount);
            var StoragenameInAscenOrder = Storage.OrderByAscending(s => s.StorageName);*/
        }

        // Changed on 11/11
        public Storage FindStorage(string storageName)
        {
            return StorageRegistry.Find(x => x.Name == storageName);
        }
        /*
         *   Comment - Requirement
         *   SendVehicleTo Command
         *   Parameters
         *      sourceName – string
         *      garageSlot – int
         *      destinationName – string
         *   Functionality
         *      If either the source storage or the destination storages don’t exist, throw an InvalidOperationException with the message "Invalid source storage!" or "Invalid destination storage!"
         *      Then, the method gets the vehicle from the storage at the provided garage slot and sends it to the destination storage.
         *      Returns "Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})".
         */
        public string SendVehicleTo(string sourceName, int garageSlot, string destinationName)
        {
            Storage sourceStorage = FindStorage(sourceName);
            Storage destinationStorage = FindStorage(destinationName);
            string vehicleType;
            int destinationGarageSlot;
            try
            {
                if (sourceStorage == null)
                {
                    throw new InvalidOperationException("Invalid source storage!");
                }
                if (destinationStorage == null)
                {
                    throw new InvalidOperationException("Invalid destination storage!");
                }
             vehicleType = sourceStorage.Garage[garageSlot].GetType().Name;

               destinationGarageSlot = sourceStorage.SendVehicleTo(garageSlot, destinationStorage);
            }
            catch(Exception ex) { return ex.Message; }

            

            return $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";

        }

        /*   
         *   Comment - Requirement
         *   UnloadVehicle Command
         *   Parameters
         *      storageName – string
         *      garageSlot – int
         *   Functionality
         *      The method gets the vehicle in the storage’s garage slot. Then, the vehicle is unloaded at the storage.
         *      The method returns "Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}".
         */
        public string UnloadVehicle(string storageName, int garageSlot)
        {
            try
            {
                Storage s = FindStorage(storageName);

                int productsInVehicle = s.NumOfItemsInVehicle(garageSlot);
                int unloadedProductsCount = s.UnloadVehicle(garageSlot);
            
            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
            }
            catch (Exception ex) { return ex.Message; }
        }

       /* 
        * The method gets all the storages in the storage registry, ordered by the sum of their products’ price
        * (descending). For each one, a string is produced in the following format:
        *    {storageName}:Storage worth: ${totalMoney:F2}
        *    The method returns all the formatted storage strings, separated by new lines. 
        */

        public string GetSummary()
        {
            double total=0;
            string output = "";
            foreach (Storage s in StorageRegistry)
            {
                foreach(Product p in s.products)
                {
                    total += p.Price;
                }
                output += "{ "+ s.Name+ "}:Storage worth:{" +total+ "}\n";
            }
            return output;
        }
    }
}
