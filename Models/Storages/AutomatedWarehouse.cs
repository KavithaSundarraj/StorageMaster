using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StorageMaster.Models.Storages
{
    class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) : base(name, capacity, garageSlots, vechicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
        }
    }
}
