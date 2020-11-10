using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    class Warehouse : Storage
    {
        public Warehouse(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles) : base(name, capacity, garageSlots, vehicles)
        {
            this.Name = name;
            this.Capacity = 10;
            this.GarageSlots = 10;

            // ***  array.
            garage = new Vehicle[garageSlots];
            Truck truck = new Truck();
            garage

        }
        }
    }

