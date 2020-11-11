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
        public Gpu(double price): base( price)
        {
            this.Price = price;
            this.Weight = 0.7;
            this.Type = "Gpu";
        }
    }
}
