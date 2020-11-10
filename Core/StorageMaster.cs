using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core
{
    class StorageMaster
    {
        public List<Product> ProductPool;
        Product p;
        public List<Storage> StorageRegistry;
        Storage s;
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
                    s = new AutomatedWarehouse(name); //The constructor needs to get it's parameters trimmed. Capacity and vehicles shouldn't be parameters. They are already decided by type
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
            return null; // todo
        }
    }
   
    
}
