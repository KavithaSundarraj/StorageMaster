using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StorageMaster.Models.Storages
{
    class DistributionCenter: Storage
    {
        public DistributionCenter(string name) : base(name)
        {
            this.Name = name;
            this.Capacity = 2;
            this.GarageSlots = 5;

            public Vehicle[] Garage = new Vehicle[GarageSlots];

            Van van1 = new Van();
            Garage[0] = van1;
            Van van2 = new Van();
            Garage[1] = van2;
            Van van3 = new Van();
            Garage[2] = van3;

        }
    }
}
