using System;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StorageMaster.Models.Storages
{
   public abstract class Storage
    {
        /*      
        Name – string
        Capacity – int – the maximum weight of products the storage can handle
        GarageSlots – int – the number of garage slots the storage’s garage has
        IsFull – bool
            Returns true if the sum of the products’ weights is equal to or larger than the storage capacity (calculated property)
        Garage – IReadOnlyCollection of vehicles
        */
        public string  Name { get; set; }  // Name – string
        public int Capacity { get; set; }  // Capacity – int – the maximum weight of products the storage can handle
        public int GarageSlots { get; set; }  // GarageSlots – int – the number of garage slots the storage’s garage has

        //  protected IReadOnlyCollection<Vehicle> garage;
        public Vehicle[] Garage ;

        //  public IReadOnlyCollection<Product> products;
        public List<Product> products = new List<Product>();  // List of all products in this Storage

        // Calculate total weight of all products in "this" inventory
        public double TotalWeightofAllProducts()
        {
            double totalWeight = 0;
            foreach (Product p in products)
            {
                totalWeight += p.Weight;
                
            }
            
            return totalWeight;
        }

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

        // Constructor
        public Storage(string name)  
        {
            this.Name = name;
        }

        /*        
            Vehicle GetVehicle(int garageSlot)
            If the provided garage slot number is equal to or larger than the garage slots, throw an InvalidOperationException with the message "Invalid garage slot!".
            If the garage slot is empty, throw an InvalidOperationException with the message "No vehicle in this garage slot!"
        */
        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(@"Invalid garage slot!");
            }
            else if (garageSlot == 0)
            {
                throw new InvalidOperationException(@"No vehicle in this garage slot!!");
            }

                return this.Garage[garageSlot];      
        }

        //  Input: garageSlot 
        //  Return: Number of Items loaded in the designated vehicle
        public int NumOfItemsInVehicle(int garageSlot)
        {
            Vehicle vehicle = GetVehicle(garageSlot);
            if (vehicle == null)
            {
                throw new InvalidOperationException(@"Vehicle Not Found (Possibly wrong storage or  wrong slot selected)!!");
            }
            else
            {
                return vehicle.Trunk.Count;
            }
        }

        /*
            int SendVehicleTo(int garageSlot, Storage deliveryLocation)
            Gets the vehicle from the specified garage slot(and delegates the validation of the garage slot to the GetVehicle method).
            Then, the method checks if there are any free garage slots.A free garage slot is denoted by a null value.
            If there is no free garage slot, throw an InvalidOperationException with the message "No room in garage!".
            Then, the garage slot in the source storage is freed and the vehicle is added to the first free garage slot.
            The method returns the garage slot the vehicle was assigned when it was transferred.
        */
        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);

            for (int i = 1; i < deliveryLocation.GarageSlots+1; i++) // Array starts from 1 (not 0) as Garage slots starts from 1
            {
                if (deliveryLocation.Garage[i] == null)
                {
                    this.Garage[garageSlot] = null;
                    deliveryLocation.Garage[i] = vehicle; 
                    return i;  
                }
            }
            throw new InvalidOperationException(@"No room in garage!!");
        }

        /*
            int UnloadVehicle(int garageSlot)
            If the storage is full, throw an InvalidOperationException with the message "Storage is full!".
            Gets the vehicle from the specified garage slot(and delegates the validation of the garage slot to the GetVehicle method).
            Then, until the vehicle empties, or the storage fills up, the vehicle’s products are unpacked and are added to the storage’s products.
            The method returns the number of unloaded products.
        */
        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull())
                {
                throw new InvalidOperationException(@"Storage is Full!!");
            }
            Vehicle vehicle = Garage[garageSlot];

            int numOfUnloadedProducts = 0;
            if (vehicle == null)
            {
                throw new InvalidOperationException(@"Vehicle Not Found (Possibly wrong storage or  wrong slot selected)!!");
            }
            else
            {
                while (!vehicle.IsVehicleEmpty())
                {
                    this.products.Add(vehicle.Unload());
 //                   Console.WriteLine(vehicle.Unload());
                    numOfUnloadedProducts++;
                }
            }
            return numOfUnloadedProducts;
        }
    }

}


