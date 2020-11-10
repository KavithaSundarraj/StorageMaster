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
            //need fix for exceptions
        foreach(Storage s in StorageRegistry )
            {
                if(s.Name==StorageName)
                {

                    selectedvehicle = s.garage[GarageSlot];
                }

            }

        //we need name of selected vehicle
        return $"{selectedvehicle}";
    }

     public string LoadVehicle(string Productnames)
        {
           // ProductPool.FindLast(Productnames);
            foreach (Product p in ProductPool)
            {
                
                if ((p.GetType().ToString() )== Productnames)
                {
                    
                    
                }

            }

            return null;
        }

    }
}
