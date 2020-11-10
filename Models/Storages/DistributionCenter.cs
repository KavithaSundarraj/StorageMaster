using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StorageMaster.Models.Storages
{
    class DistributionCenter: Storage
    {
        public DistributionCenter(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) : base(name, capacity, garageSlots, vehicles)
        {
            this.Name = name;
            this.Capacity = 1;
            this.GarageSlots = 2;

            Van van = new Van();
            vehicles.add(van);
            vehicles.add(van);
            vehicles.add(van);
        }
    }
}
