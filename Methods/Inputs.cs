using file_manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Methods
{
	public class Inputs
	{
		public static int getValidInt()
		{
			int inputInt = 0;
			if (!int.TryParse(Console.ReadLine(), out inputInt))
			{
				Console.WriteLine("Input is not a valid integer value.");
				return getValidInt();
			}
			return inputInt;
		}
		public static double getValidDouble()
		{
			double inputDouble = 0;
			if (!double.TryParse(Console.ReadLine(), out inputDouble))
			{
				Console.WriteLine("Input is not a valid double value.");
				return getValidDouble();
			}
			return inputDouble;
		}
        public static bool LicensePlateExists(List<Car> cars, string licensePlate)
        {
            return cars.Any(car =>
                string.Equals(car.LicensePlate, licensePlate.ToUpper(), StringComparison.OrdinalIgnoreCase));
        }
        public static string getValidLicensePlate(List<Car> cars)
		{
			string inputLicense = "";
			inputLicense = Console.ReadLine();
			if (!Car.IsValidLicensePlate(inputLicense))
			{
				Console.WriteLine("Valid formats: ABC-123 or AA-AA-123");
				return getValidLicensePlate(cars);
			}
			else if (LicensePlateExists(cars, inputLicense.ToUpper()))
			{
                Console.WriteLine("This license plate is already exist in the list!");
                return getValidLicensePlate(cars);
            }
			return inputLicense;
		}
		public static Car inputData(List<Car> cars)
		{
			Car tempCar = new Car();
			Console.WriteLine("Creating new Car...");

			Console.Write("Input the car's license plate: ");
			tempCar.LicensePlate = Inputs.getValidLicensePlate(cars);

			Console.Write("Input the car's brand: ");
			tempCar.Brand = Console.ReadLine();

			Console.Write("Input the car's name: ");
			tempCar.Name = Console.ReadLine();

			Console.Write("Input the car's color: ");
			tempCar.Color = Console.ReadLine();

			Console.Write("Input the car's price: ");
			tempCar.Price = Inputs.getValidDouble();

			Console.Write("Input the car's horsepower: ");
			tempCar.Price = Inputs.getValidInt();

			Console.Write("Inpupt the car's consumption (city, mixed, highway): \n");
            Console.Write("City: ");
			double city = Inputs.getValidDouble();
            Console.Write("Mixed: ");
			double mixed = Inputs.getValidDouble();
            Console.WriteLine("Highway: ");
            double highway = Inputs.getValidDouble();
            tempCar.SetConsumption(city,mixed,highway);
			return tempCar;
		}
		public static void InputCarToList(List<Car> cars) {
            Console.Write("How many car do you want to add?: ");
            int count = getValidInt();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i}.:");
                cars.Add(inputData(cars));
            }
            Console.WriteLine("Cars saved sucessfully!\nPress ENTER to continue...");
			Console.ReadKey();
            return;
        }

	}
}
