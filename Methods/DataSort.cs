using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using file_manager.Classes;
using file_manager.FileManager;

namespace file_manager.Methods
{
    public class DataSort
    {
        public static void SortMenu(string fileName,List<Car> cars)
        {
            if (cars == null || cars.Count == 0)
            {
                Console.WriteLine("No cars available for sorting.");
                Console.WriteLine("Press ENTER to continue...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SORT CARS ===");
                Console.WriteLine("1. Sort by License Plate (A-Z)");
                Console.WriteLine("2. Sort by License Plate (Z-A)");
                Console.WriteLine("3. Sort by Brand (A-Z)");
                Console.WriteLine("4. Sort by Brand (Z-A)");
                Console.WriteLine("5. Sort by Horsepower (Low-High)");
                Console.WriteLine("6. Sort by Horsepower (High-Low)");
                Console.WriteLine("7. Sort by Mixed Consumption (Low-High)");
                Console.WriteLine("8. Sort by Mixed Consumption (High-Low)");
                Console.WriteLine("9. Sort by Price (Low-High)");
                Console.WriteLine("10. Sort by Price (High-Low)");
                Console.WriteLine("11. Back to Main Menu");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                List<Car> sortedCars = new List<Car>();
                string sortOrder = "";

                switch (choice)
                {
                    case "1":
                        sortedCars = cars.OrderBy(car => car.LicensePlate).ToList();
                        sortOrder = "License Plate (A-Z)";
                        break;
                    case "2":
                        sortedCars = cars.OrderByDescending(car => car.LicensePlate).ToList();
                        sortOrder = "License Plate (Z-A)";
                        break;
                    case "3":
                        sortedCars = cars.OrderBy(car => car.Brand).ToList();
                        sortOrder = "Brand (A-Z)";
                        break;
                    case "4":
                        sortedCars = cars.OrderByDescending(car => car.Brand).ToList();
                        sortOrder = "Brand (Z-A)";
                        break;
                    case "5":
                        sortedCars = cars.OrderBy(car => car.HorsePower).ToList();
                        sortOrder = "Horsepower (Low-High)";
                        break;
                    case "6":
                        sortedCars = cars.OrderByDescending(car => car.HorsePower).ToList();
                        sortOrder = "Horsepower (High-Low)";
                        break;
                    case "7":
                        sortedCars = cars.OrderBy(car => car.GetMixedConsumption()).ToList();
                        sortOrder = "Mixed Consumption (Low-High)";
                        break;
                    case "8":
                        sortedCars = cars.OrderByDescending(car => car.GetMixedConsumption()).ToList();
                        sortOrder = "Mixed Consumption (High-Low)";
                        break;
                    case "9":
                        sortedCars = cars.OrderBy(car => car.Price).ToList();
                        sortOrder = "Price (Low-High)";
                        break;
                    case "10":
                        sortedCars = cars.OrderByDescending(car => car.Price).ToList();
                        sortOrder = "Price (High-Low)";
                        break;
                    case "11":
                        return;
                    default:
                        Console.WriteLine("Invalid option! Press ENTER to try again...");
                        Console.ReadKey();
                        continue;
                }
                Console.WriteLine($"Sorted cars by {sortOrder}: ");
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
                CarFileManager.SaveDataToFile(fileName, cars);
                Console.WriteLine("Cars Sorted and saved sucessfully!\nPress ENTER to continue");
                Console.ReadKey();
                
            }
        }
    }
}