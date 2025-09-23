using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using file_manager.Classes;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace file_manager
{
    internal class Program
    {
        const string fileName = "data.bin";
        public static void WriteToFile()
        {
            using (var stream = File.Open(fileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    writer.Write(1.250F);
                    writer.Write(@"c:\Temp");
                    writer.Write(10);
                    writer.Write(true);
                }


            }
        }
        public static void DisplayValues()
        {
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;

            if (File.Exists(fileName))
            {
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        aspectRatio = reader.ReadSingle();
                        tempDirectory = reader.ReadString();
                        autoSaveTime = reader.ReadInt32();
                        showStatusBar = reader.ReadBoolean();
                    }
                }

                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
            }
        }
        public static void menu() {
            do
            {
                Console.WriteLine($"Menu:\nDisplay data:\t1\nInput data:\t2\nSearch by license plate:\t3\nDelete record:\t4\nSort records:\t5\n");








            }
            while (true);


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
            tempCar.LicensePlate = getValidLicensePlate();

			Console.Write("Input the car's brand: ");
            tempCar.Brand = Console.ReadLine();

			Console.Write("Input the car's name: ");
            tempCar.Name = Console.ReadLine();

			Console.Write("Input the car's color: ");
            tempCar.Color = Console.ReadLine();

			Console.Write("Input the car's price: ");
            tempCar.Price = getValidDouble();

			Console.Write("Input the car's horsepower: ");
			tempCar.Price = getValidInt();

			Console.Write("Inpupt the car's consumption (city, mixed, highway): ");
            tempCar.SetConsumption(getValidDouble(), getValidDouble(), getValidDouble());

            return tempCar;
		}

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
            if (!double.TryParse(Console.ReadLine(),out inputDouble))
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

        public static void SortOptions(int opt) {
            //wip xddd
            
            return;
        
        }
        static void Main(string[] args)
        {
            WriteToFile();
            DisplayValues();
            //Car testCar = new Car("IAP-512","Ford","Focus Mk1",75,"Gray",879000,7.6,6.3,5.5);
            Car testCar = inputData();
            Console.WriteLine(testCar);
            Console.ReadKey();

        }
    }
}