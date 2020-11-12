﻿using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string storagetype, string name)
        {
            switch (storagetype)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
