using file_manager.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Methods
{
    public class Delete
    {
        public static void DeleteByLicensePlate(List<Car> cars)
        {
            Console.Write("Enter a valid license plate: ");
            string licensePlate = Console.ReadLine();
            var carPlate = cars.FirstOrDefault(c => c.LicensePlate == licensePlate);
            if (Car.IsValidLicensePlate(licensePlate) && Inputs.LicensePlateExists(cars, licensePlate))
            {
                Console.WriteLine(carPlate);
            }
            else
            {
                Console.WriteLine("There is no such license plate!");
            }

            try
            {
                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    Console.WriteLine("Incorrect license plate number");
                    return;
                }

                if (cars == null || cars.Count == 0)
                {
                    Console.WriteLine("The car list is empty");
                    return;
                }

                // Törlés
                int removedCount = cars.RemoveAll(car => car.LicensePlate == licensePlate.ToUpper());

                if (removedCount > 0)
                {
                    Console.WriteLine($" {licensePlate} has been deleted");
                }
                else
                {
                    Console.WriteLine($"No car found with license plate {licensePlate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during deletion: {ex.Message}");
            }
            Console.WriteLine("Cars saved sucessfully!\nPress ENTER to continue...");
            Console.ReadKey();
        }
    }
}
