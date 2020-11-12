using StorageMaster.IO.Contracts;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Core;

namespace StorageMaster.IO
{
    public class ConsoleDataReader : IReader
    {
        public void getinput()
        {
            String[] splitup;
            do
            {
                String getLine = Console.ReadLine();
                splitup = getLine.Split();
                StorageMasters s = new StorageMasters();
                String output = "";
                ConsoleDataWriter CDW = new ConsoleDataWriter();


                switch (splitup[0])
                {
                    case "RegisterStorage":
                        output = s.RegisterStorage(splitup[1], splitup[2]);
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "AddProduct":
                        output = s.AddProduct(splitup[1], Int32.Parse(splitup[2]));
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "SelectVehicle":
                        Console.WriteLine(splitup[1]);
                        Console.WriteLine(Int32.Parse(splitup[2]));
                        output = s.SelectVehicle(splitup[1], Int32.Parse(splitup[2]));
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "LoadVehicle":
                        output = s.LoadVehicle(splitup[1], splitup[2]);
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "SendVehicleTo":
                        output = s.SendVehicleTo(splitup[1], Int32.Parse(splitup[2]), splitup[3]);
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "UnloadVehicle":
                        output = s.UnloadVehicle(splitup[1], Int32.Parse((splitup[2])));
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "GetStorageStatus":
                        output = s.GetStorageStatus(splitup[1]);
                        CDW.display(output);
                        Console.WriteLine(output);
                        break;
                    case "END":
                        output = s.GetSummary();
                        CDW.display(output);
                        Console.WriteLine(output);
                        CDW.output();
                        break;
                    default:
                        break;

                }

            }while(splitup[0]!="END");
            
            
            

        }

        
    }
}
