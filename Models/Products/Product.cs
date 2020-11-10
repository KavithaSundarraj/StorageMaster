using System;
using System.Collections.Generic;
using System.Text;

/*OOP Exam – Warehouse management
 * Product is a base class for any products and it should not be able to be instantiated. 
 Data
•	Price – double
o	If a negative price is entered, throw an InvalidOperationException with the message “Price cannot be negative!”
•	Weight – double
Constructor
A product should take the following values upon initialization:
double price, double weight
*/

namespace StorageMaster.Models.Products
{
  public class Product
    {
        double price;
        double weight;
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if(value<0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
            }
        }
        public Product(double price,double weight)
        {
            this.price = price;
            this.weight = weight;
        }

    }
}
