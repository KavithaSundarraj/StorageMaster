using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        public double Capacity { get; set; }
        //public IReadOnlyCollection<Product> Trunk => this.Trunk.AsReadOnly();
        public List<Product> Trunk = new List<Product>();
        public bool IsFuLL;
        public bool IsEmpty;
        public double TotalWeight;
        public string Type;

        public Vehicle()
        {

        }

        public void LoadProduct(Product product)
        {
            if (this.IsFuLL)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            else
            {
                this.Trunk.Add(product);
                TotalWeight += product.Weight;
                CheckIfFull();
            }
        }
        public void CheckIfFull()
        {
            if (TotalWeight >= Capacity)
            {
                IsFuLL = true;
            }
        }
        public void CheckIfEmpty()
        {
            if (Trunk.Count == 0)
            {
                IsEmpty = true;
            }
        }

        public bool IsVehicleEmpty()  // Added by Daryl on 11/11
        {
            return Trunk.Count == 0 ? true : false;

        }

        public Product Unload()
        {
            if (IsVehicleEmpty())
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            else
            {
                //  edited by Daryl 11/11
                Product unloadedItem = Trunk[Trunk.Count-1];
                TotalWeight -= unloadedItem.Weight;
                this.Trunk.RemoveAt(Trunk.Count-1);
                CheckIfEmpty();
                return unloadedItem;

            }
        }

    }
}