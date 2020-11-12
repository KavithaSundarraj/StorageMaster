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
    public abstract class Product
    {
        double price;
        double weight;
        public string Type;
        public double Price

        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                //               edited by Daryl
                this.price = value;
            }
        }
        public double Weight
        {
            get
            {
                //               edited by Daryl
                //               return weight;
                return this.weight;
            }
            set
            {
                //               edited by Daryl
                if (value < 0)
                {
                    throw new InvalidOperationException("Weight cannot be negative!");
                }
                //               edited by Daryl
                this.weight = value;
            }
        }
        public Product(double price)
        {
            this.price = price;

        }



    }
}
