using System;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StorageMaster.Models.Storages
{
    abstract class Storage
    {
        

        protected string  Name { get; set; }  // Name – string
        protected int Capacity { get; set; }  // Capacity – int – the maximum weight of products the storage can handle
        protected int GarageSlots { get; set; }  // GarageSlots – int – the number of garage slots the storage’s garage has
        


        protected IEnumerable<Vehicle> vehicles;
//      protected IReadOnlyCollection<Vehicle> garage;
        protected Vehicle[] garage;

        protected IReadOnlyCollection<Product> products;
//      List<Product> product = new List<Product>();  // List of all products in this Storage

        // Returns true if the sum of the products’ weights is equal to or larger than the storage capacity (calculated property)
        public bool IsFull()
        {
                double totalWeight = 0;
                foreach (Product p in products)
                {
                    totalWeight += p.Weight;
                }
                if (totalWeight >= this.Capacity)
                    return true;
                else
                    return false;
        }
        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.vehicles = vehicles;

            // ***  array.
            garage = new Vehicle[garageSlots];

            // Copy the vechicles from a List to the garage array
            int i = 0;
            foreach (Vehicle veh in vehicles)
            {
                garage[i++] = veh;
            }
        }

        Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(@"Invalid garage slot!");
            }
            else if (garageSlot == 0)
            {
                throw new InvalidOperationException(@"No vehicle in this garage slot!!");
            }
            else
                return garage[garageSlot];       
        }

        int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            for (int i = 0; i < deliveryLocation.GarageSlots; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    this.garage[garageSlot] = null;
                    return i;
                }
            }
            throw new InvalidOperationException(@"No room in garage!!");
        }

        int UnloadVehicle(int garageSlot)
        {
            if (IsFull())
                {
                throw new InvalidOperationException(@"Storage is Full!!");
            }

            Vehicle vehicle = GetVehicle(garageSlot);

            int numOfUnloadedProducts = 0;
            while (!vehicle.isEmpty())
            {
                this.product.Add(vehicle.unload());
                numOfUnloadedProducts++;
            }

            return numOfUnloadedProducts;
        }
    }

}


