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
            /*      
            Name – string
            Capacity – int – the maximum weight of products the storage can handle
            GarageSlots – int – the number of garage slots the storage’s garage has
            IsFull – bool
                Returns true if the sum of the products’ weights is equal to or larger than the storage capacity (calculated property)
            Garage – IReadOnlyCollection of vehicles
            */
            this.Name = name;
            this.Capacity = 2;
            this.GarageSlots = 5;

            Garage = new Vehicle[GarageSlots+1];  // Garage slot number begin from 1 not 0

            
            Van van1 = new Van();
            Garage[1] = van1;     // Garrage array starts from 1 as Slot starts from 1
            Van van2 = new Van();
            Garage[2] = van2;     
            Van van3 = new Van();
            Garage[3] = van3;     

        }
    }
}
