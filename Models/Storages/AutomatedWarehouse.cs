using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageMaster.Models.Storages
{
   public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name) : base(name)
        {
            this.Name = name;
            this.Capacity = 1;
            this.GarageSlots = 2;

//            public Vehicle[] Garage = new Vehicle[GarageSlots];

            Truck truck = new Truck();
            Garage[0] = truck;

        }
    }
}
