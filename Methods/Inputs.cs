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

		public static string getValidLicensePlate()
		{
			string inputLicense = "";
			inputLicense = Console.ReadLine();
			if (!Car.IsValidLicensePlate(inputLicense))
			{
				Console.WriteLine("Valid formats: ABC-123 or AA-AA-123");
				return getValidLicensePlate();
			}
			return inputLicense;
		}
		public static Car inputData()
		{
			Car tempCar = new Car();
			Console.WriteLine("Creating new Car...");

			/*
            private string licensePlate;
            private string brand;
            private string name;
            private string color;
            private double price;
            private int horsePower;
            private double[] consumption = new double[3];
            private bool isEconomy;
            */

			Console.Write("Input the car's license plate: ");
			tempCar.LicensePlate = Inputs.getValidLicensePlate();

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

			Console.Write("Inpupt the car's consumption (city, mixed, highway): ");
			tempCar.SetConsumption(Inputs.getValidDouble(), Inputs.getValidDouble(), Inputs.getValidDouble());

			return tempCar;
		}

	}
}
