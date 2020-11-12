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
            //If file not exists , create an new file
            if (!File.Exists(path))
            {
                TextWriter tw = new StreamWriter(File.Create(path));
                tw.WriteLine(output);
                tw.Close();
            }
            //If file exists Already
            else if (File.Exists(path))
            { 
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(output);
                }
            }

        }

        //printing the whole output in console
        public void output()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
               sr.Close();
                // delete file after displaying whole output
                File.Delete(path);
                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
 }

