﻿using StorageMaster.Models.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
      
        public Warehouse(string name) : base(name)
        {
            /*      
            Name – string
            Capacity – int – the maximum weight of products the storage can handle
            GarageSlots – int – the number of garage slots the storage’s garage has
            IsFull – bool
                Returns true if the sum of the products’ weights is equal to or larger than the storage capacity (calculated property)
            Garage – IReadOnlyCollection of vehicles
            */
            this.Name = name;
            this.Capacity = 10;
            this.GarageSlots = 10;

            Garage = new Vehicle[GarageSlots+1];  // Garage slot number begin from 1 not 0

            // Garage array starts from 1 not 0

            
            Garage[1] = this.vehicleFactory.CreateVehicle("Semi");     // Garrage array starts from 1 as Slot starts from 1
            Garage[2] = this.vehicleFactory.CreateVehicle("Semi");
            Garage[3] = this.vehicleFactory.CreateVehicle("Semi");
            
        }

    }
}

