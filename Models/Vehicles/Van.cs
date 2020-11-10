using System;
using System.Collections.Generic;
using System.Text; 
/*  The Vehicle is a base class for any vehicles and it should not be able to be instantiated.
Data
· Capacity – int
There are several concrete types of products:
· Van – always has 2 capacity */

namespace StorageMaster.Models.Storages
{
    class Van : Vehicle
    {
        Van()
        {
            Capacity = 2.0;
        }
     }
}
