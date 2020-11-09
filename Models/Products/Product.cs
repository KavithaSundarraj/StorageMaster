using System;
using System.Collections.Generic;
using System.Text;
/*Product is a base class for any products and it should not be able to be instantiated. */

namespace StorageMaster.Models.Products
{
  class Product
    {
        Double Price { get; set; }
        Double Weight { get; set; }
        Product(Double price, Double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

    }
}
