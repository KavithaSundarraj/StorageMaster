using System;
using System.Collections.Generic;
using System.Text;
/*OOP Exam – Warehouse management
 * Ram is the child class of Product
 •	Ram – always has 0.1 weight*/
namespace StorageMaster.Models.Products
{
    class Ram : Product
    {
        public Ram(double price) : base(price)
        {
            this.Price = price;
            this.Weight = 0.1;
            this.Type = "Ram";
        }
    
    }
}
