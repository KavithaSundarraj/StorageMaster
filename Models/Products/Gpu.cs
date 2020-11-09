using System;
using System.Collections.Generic;
using System.Text;
/*OOP Exam – Warehouse management
 * Gpu is the child class of Product
 •	Gpu – always has 0.7 weight*/

namespace StorageMaster.Models.Products
{
    class Gpu : Product
    {
        public Gpu(Double price, double weight = 0.7) : base(price, weight)
        {
            this.Price = price;
            this.Weight = 0.7;
        }
    }
}
