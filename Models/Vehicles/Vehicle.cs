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
        bool IsFuLL;
        bool IsEmpty;
        double TotalWeight;

        void LoadProduct(Product product)
        {
            if(this.IsFuLL)
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
        void CheckIfFull()
        {
            if (TotalWeight >= Capacity)
            {
                 IsFuLL = true;
            }
        }
        void CheckIfEmpty()
        {
            if(Trunk.Count == 0)
            {
                IsEmpty = true;
            }
        }

        Product Unload()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            else
            {
                Product unloadedItem = Trunk[Trunk.Count];
                TotalWeight -= unloadedItem.Weight;
                this.Trunk.RemoveAt(Trunk.Count);
                CheckIfEmpty();
                return unloadedItem;
            }
        }
        
    }
}
