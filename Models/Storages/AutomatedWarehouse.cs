using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StorageMaster.Models.Storages
{
    class AutomatedWarehouse : Storage
    {
        AutomatedWarehouse(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) : base(name, capacity, garageSlots, vehicles)
        {
            this.Name = name;
            this.Capacity = 1;
            this.GarageSlots = 2;

            // ***  array.
            garage = new Vehicle[garageSlots];
            Truck truck = new Truck();
            garage

        }
    }
}
