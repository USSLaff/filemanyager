using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using file_manager.Classes;
using System.Diagnostics;
using file_manager.Methods;

namespace file_manager
{
    internal class Program
    {
        public static List<Car> cars;
        
        const string fileName = "data.bin";
        public static void WriteToFile()
        {
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(1.250F);
                    writer.Write(@"c:\Temp");
                    writer.Write(10);
                    writer.Write(true);
                }


            }
        }
        public static void DisplayValues()
        {
            
            if (File.Exists(fileName))
            {
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                       
                    }
                }

            }
        }
       
        public static void SortOptions(int opt) {
                //wip xddd
            
            return;
        
        }
        static void Main(string[] args)
        {
            
            WriteToFile();
            DisplayValues();
            Car testCar = new Car("IAP-512","Ford","Focus Mk1",75,"Gray",879000,7.6,6.3,5.5);
            Console.WriteLine(testCar);
            UserInterfaces.menu();
            Console.ReadKey();

        }
    }
}
