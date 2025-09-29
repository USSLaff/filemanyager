using file_manager.Classes;
using file_manager.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using file_manager.Methods;

namespace file_manager.Methods
{

    internal class UserInterfaces
    {

        public static void menu(string fileName)
        {
            List<Car> cars = new List<Car>();
            cars = CarFileManager.ReadCarsFromBinaryFile(fileName);
            do
            {
               
                Console.Clear();
                string option;
                Console.WriteLine($"Menu:\nDisplay data:\t1\nInput data:\t2\nSearch:\t\t3\nDelete record:\t4\nSort records:\t5\nExit:\t\t0");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Display.DisplayData(cars);
                        break;
                    case "2":
                        Inputs.InputCarToList(cars);
                        CarFileManager.SaveDataToFile(fileName, cars);
                        break;
                    case "3":
                        // search bazsi
                        SearchOptions.SearchOptionsMenu(fileName, cars);
                        break;
                    case "4":
                        //delete 
                        //ide tedd olivért a metódusod nevéd az ez alatt lévő sor csak lementi a lsitát a fájlba :3
                        CarFileManager.SaveDataToFile(fileName, cars);
                        break;
                    case "5":
                        //sort
                        DataSort.SortMenu(fileName, cars);
                        break;
                    case "0":
                        CarFileManager.SaveDataToFile(fileName, cars);
                        Console.WriteLine("Cars saved sucessfully!\nPress ENTER to Exit!");
                        Console.ReadKey();
                        Console.WriteLine("Bye!");
                        Console.ReadKey();
                    
                        

                        return;
                    default:
                        Console.WriteLine("It's not an option!\nPress a button to continue....");
                        Console.ReadKey();
                        continue;
                }




            }
            while (true);
            

        }
    }
}
