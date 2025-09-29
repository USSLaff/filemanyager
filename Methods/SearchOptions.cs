using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using file_manager.Classes;

namespace file_manager.Methods
{
    internal class SearchOptions
    {
        public static void SearchOptionsMenu(string fileName, List<Car> cars)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Search options:\nLicense plate:\t1\nBrand:\t\t2\nName:\t\t3\nColor:\t\t4\nHorsepower:\t5\nPrice:\t\t6\nExit:\t\t0");
                Console.Write("\nEnter your number: ");
                string opt;
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Write("Enter a valid license plate: ");
                        string plate = Console.ReadLine();
                        var carPlate = cars.FirstOrDefault(c => c.LicensePlate == plate);
                        if (Car.IsValidLicensePlate(plate) && Inputs.LicensePlateExists(cars, plate))
                        {
                            Console.WriteLine(carPlate);
                        }
                        else
                        {
                            Console.WriteLine("There is no such license plate!");
                        }
                        break;
                    case "2":
                        Console.Write("Enter a brand: ");
                        string brand = Console.ReadLine();
                        var carBrand = cars.Where(c => c.Brand == brand).ToList();
                        if (carBrand != null)
                        {
                            Console.WriteLine(carBrand);
                        }
                        else
                        {
                            Console.WriteLine("There is no car of this brand!");
                        }
                        break;
                    case "3":
                        Console.Write("Enter a car name: ");
                        string name = Console.ReadLine();
                        var carName = cars.Where(c => c.Name == name).ToList();
                        if (carName != null)
                        {
                            Console.WriteLine(carName);
                        }
                        else
                        {
                            Console.WriteLine("There is no car with that name!");
                        }
                        break;
                    case "4":
                        Console.Write("Enter a color: ");
                        string color = Console.ReadLine();
                        var carColor = cars.Where(c => c.Color == color).ToList();
                        if (carColor != null)
                        {
                            Console.WriteLine(carColor);
                        }
                        else
                        {
                            Console.WriteLine("There is no car of this color!");
                        }
                        break;
                    case "5":
                        Console.Write("Enter a horsepower: ");
                        int hp = int.Parse(Console.ReadLine());
                        var carHp = cars.Where(c => c.HorsePower == hp).ToList();
                        if (carHp != null)
                        {
                            Console.WriteLine(carHp);
                        }
                        else
                        {
                            Console.WriteLine("There is no car with this much horsepower!");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter a price: ");
                        double price = double.Parse(Console.ReadLine());
                        var carPrice = cars.Where(c => c.Price == price).ToList();
                        if (carPrice != null)
                        {
                            Console.WriteLine(carPrice);
                        }
                        else
                        {
                            Console.WriteLine("There is no car with this price!");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }


            } while (true);
        }
    }
}
