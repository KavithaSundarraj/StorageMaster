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
            int i = 0;  // for testing purpose
            String[] splitup;
            StorageMasters s = new StorageMasters();
            
            do
            {
                 String getLine = Console.ReadLine();
                /* //  This part is testing purpose
                 String getLine = null;
                 if (i == 0) { getLine = "RegisterStorage DistributionCen SofiaDistribution"; }
                 if (i == 1) { getLine = "RegisterStorage Warehouse AmazonWarehouse"; }
                 if (i == 2) { getLine = "AddProduct Gpu 1200"; }
                 if (i == 3) { getLine = "AddProduct SolidStateDrive 205"; }
                 if (i == 4) { getLine = "AddProduct Harddrive 70"; }
                 if (i == 5) { getLine = "AddProduct Harddrive 120"; }
                 //               if (i == 6) { getLine = "SelectVehicle SofiaDistribution 0"; }
                 if (i == 6) { getLine = "SelectVehicle SofiaDistribution 1"; }
                 if (i == 7) { getLine = "LoadVehicle SolidStateDrive Gpu"; }
                 //if (i == 8) { getLine = "SendVehicleTo SofiaDistribution 0 AmazonWarehouse"; }
                               if (i == 8) { getLine = "SendVehicleTo SofiaDistribution 1 AmazonWarehouse"; }
                 if (i == 9) { getLine = "UnloadVehicle AmazonWarehouse 4"; }
                 if (i == 10) { getLine = "END"; }
                 i++;
                 //  End of testing */

                splitup = getLine.Split();
                //  Removed by Daryl
                //        StorageMasters s = new StorageMasters();
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
                                    CDW.output();
                                    Console.WriteLine(output);
                                    break;
                                default:
                                    break;
                                    
                            }

                        }while(splitup[0]!="END");
           



        }


    }
}
