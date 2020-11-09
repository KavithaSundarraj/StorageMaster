using System;
using StorageMaster.Models.Products;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace StorageMaster.Models.Storages
{
    abstract class Storage
    {
        
        List<Product> product;

        protected string  Name { get; set; }
        protected int Capacity { get; set; }
        protected int GarageSlots { get; set; }
        protected bool IsFull { get; set; }

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vechicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;

            ReadOnlyCollection<string> garage = Array.AsReadOnly(garage);

            product = new List<Product>();
            ReadOnlyCollection<Product> Products = new ReadOnlyCollection<Product>(product);
        }

        Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException(@"Invalid garage slot!");
            }
            else if (garageSlot == 0)
            {
                throw new InvalidOperationException(@"No vehicle in this garage slot!!");
            }
            else
                return garage[garageSlot];  // yet to implment


        }

        int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            GetVehicle(garageSlot);

            for (int i = 0; i < GarageSlots.; i++)
            {
                string s = arr[i];
            }


        }

        int UnloadVehicle(int garageSlot)
        {

        }
    }

}


