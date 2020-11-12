using StorageMaster.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StorageMaster.IO
{
    public class ConsoleDataWriter : IWriter
    {
       
        public String path = Directory.GetCurrentDirectory() + @"\output.txt";
        
        public void display(String output)
        {

            if (!File.Exists(path))
            {

                TextWriter tw = new StreamWriter(File.Create(path));
                tw.WriteLine(output);
                tw.Close();
            }
            else if (File.Exists(path))
            {
                
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(output);
                }
            }

        }
        public void output()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
              
                    //close the file
                    sr.Close();
                
                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
 }

