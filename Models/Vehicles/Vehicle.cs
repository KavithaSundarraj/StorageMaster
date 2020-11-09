using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public abstract class Vehicle
    {
        double Capacity {get; set}
        //public IReadOnlyCollection<Products> Trunk => this.Trunk.AsReadOnly();
        public List<Products> Trunk;
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
                TotalWeight += product.weight;
                CheckIfFull();
	        }
        }
        void CheckIfFull(product)
        {
            if (TotalWeight >= Capacity)
            {
                 IsFuLL = true;
            }
        }

        Product Unload()
        {
            if(Trunk.Count = 0)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            else
            {
                Product unloadedItem = Trunk[Trunk.Count];
                TotalWeight -= unloadedItem.weight;
                this.Trunk.RemoveAt(Trunk.Count);
                return unloadedItem;
            }
        }
        
    }
}
