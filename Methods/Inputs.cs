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
	}
}
