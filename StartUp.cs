using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Van v = new Van();

            Console.WriteLine("This is a test!!!");
            Console.WriteLine("Object type is : {0}", v.GetType().Name);
            Console.ReadLine();
        }
    }
}
