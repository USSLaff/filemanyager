using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Methods
{
    internal class SearchOptions
    {
        public static void SearchOptions()
        {
            Car car = new Car("IAP-512", "Ford", "Focus Mk1", 500, "Gray", 879000, 7.6, 6.3, 5.5);
            do
            {
                Console.WriteLine($"\nSearch options:\nLicense plate:\t1\nBrand:\t\t2\nName:\t\t3\nExit:\t\t0");
                Console.Write("Enter your number: ");
                string opt;
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Write("Enter a valid license plate: ");
                        string plate = Console.ReadLine();
                        if (car.LicensePlate.Contains(plate))
                        {
                            Console.WriteLine($"\nLicense plate: {car.LicensePlate}\n" +
                                $"Brand: {car.Brand}\n" + $"Name: {car.Name}\n" +
                                $"Horsepower: {car.HorsePower}\n" + $"Color: {car.Color}\n" +
                                $"Price: {car.Price}" + $"\nConsumption: \n\tCity: {car.Consumption[0]} L/100Km\n\t" +
                                $"Mixed: {car.Consumption[1]} L/100Km\n\t" +
                                $"Highway: {car.Consumption[2]} L/100Km\n" +
                                $"Economy: {(car.IsEconomy ? "Cheap" : "Expensive")}");
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;
                    case "2":
                        Console.Write("Enter a brand: ");
                        string brand = Console.ReadLine();
                        if (brand == car.Brand)
                        {
                            Console.WriteLine($"\nLicense plate: {car.LicensePlate}\n" +
                                $"Brand: {car.Brand}\n" + $"Name: {car.Name}\n" +
                                $"Horsepower: {car.HorsePower}\n" + $"Color: {car.Color}\n" +
                                $"Price: {car.Price}" + $"\nConsumption: \n\tCity: {car.Consumption[0]} L/100Km\n\t" +
                                $"Mixed: {car.Consumption[1]} L/100Km\n\t" +
                                $"Highway: {car.Consumption[2]} L/100Km\n" +
                                $"Economy: {(car.IsEconomy ? "Cheap" : "Expensive")}");
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;
                    case "3":
                        Console.Write("Enter a car name: ");
                        string name = Console.ReadLine();
                        if (name == car.Name)
                        {
                            Console.WriteLine($"\nLicense plate: {car.LicensePlate}\n" +
                                $"Brand: {car.Brand}\n" + $"Name: {car.Name}\n" +
                                $"Horsepower: {car.HorsePower}\n" + $"Color: {car.Color}\n" +
                                $"Price: {car.Price}" + $"\nConsumption: \n\tCity: {car.Consumption[0]} L/100Km\n\t" +
                                $"Mixed: {car.Consumption[1]} L/100Km\n\t" +
                                $"Highway: {car.Consumption[2]} L/100Km\n" +
                                $"Economy: {(car.IsEconomy ? "Cheap" : "Expensive")}");
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;
                    case "0":
                        return;

                }


            } while (true);
        }
    }
}
