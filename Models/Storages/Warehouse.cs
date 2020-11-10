using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    class Warehouse : Storage
    {
        public Warehouse(string name) : base(name)
        {
            this.Name = name;
            this.Capacity = 10;
            this.GarageSlots = 10;

            Vehicle[] garage = new Vehicle[GarageSlots];

            Semi semi1 = new Semi();
            garage[0] = semi1;
            Semi semi2 = new Semi();
            garage[1] = semi2;
            Semi semi3 = new Semi();
            garage[2] = semi3;
        }
        }
    }

