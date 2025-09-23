using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Methods
{
    internal class UserInterfaces
    {
        public static void menu()
        {
            do
            {
                Console.Clear();
                string option;
                Console.WriteLine($"Menu:\nDisplay data:\t1\nInput data:\t2\nSearch:\t\t3\nDelete record:\t4\nSort records:\t5\nExit:\t\t0");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // displaydata adam
                        break;
                    case "2":
                        // inputdata 
                        break;
                    case "3":
                        // search bazsi
                        break;
                    case "4":
                        //delete 
                        break;
                    case "5":
                        //sort adam
                        break;
                    case "0":
                        Console.WriteLine("Bye!");
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
