using file_manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Methods
{
    public class Display
    {
        public static void DisplayData(List<Car> cars) { 
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadKey();
        }




    }
}
