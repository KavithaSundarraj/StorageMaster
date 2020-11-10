using System;
using System.Collections.Generic;
using System.Text;
/*OOP Exam – Warehouse management
 * Harddrive is the child class of Product
 •	Harddrive – always has 1 weight*/
namespace StorageMaster.Models.Products
{
    class Harddrive : Product
    {
        public Harddrive(double price ): base(price)
        {
            this.Price = price;
            this.Weight = 1;
        }
    }
}
