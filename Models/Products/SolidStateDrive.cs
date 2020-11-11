using System;
using System.Collections.Generic;
using System.Text;
/*OOP Exam – Warehouse management * Solid-statedrive is the child class of Product 
•solidstatedrive – always has 0.2 weight*/ 
namespace StorageMaster.Models.Products
{ 
class SolidStateDrive : Product
{ 
public SolidStateDrive(Double price) : base(price) 
{ 
this.Price = price;
this.Weight = 0.2; this.Type = "SolidStateDrive";
        } 
}
}

