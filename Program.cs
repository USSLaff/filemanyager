using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using file_manager.Classes;
using file_manager.Methods;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using file_manager.FileManager;

namespace file_manager
{
	internal class Program
	{
		public const string fileName = "data.bin";
		
		




		public static void SortOptions(int opt)
		{
			//wip xddd

			return;

		}
		static void Main(string[] args)
		{
			List<Car> cars = new List<Car>();
            //WriteToFile();

            List<Car> pucuscars = new List<Car>
			{
			    new Car("ABC-123", "Toyota", "Corolla", 120, "Fehér", 5200000, 8.2, 6.8, 5.9),
			    new Car("DEF-456", "Volkswagen", "Golf", 110, "Fekete", 4800000, 7.9, 6.5, 5.7),
			    new Car("GHI-789", "Opel", "Astra", 105, "Kék", 4500000, 8.1, 6.7, 5.8),
			    new Car("JKL-012", "BMW", "3 Series", 184, "Ezüst", 12500000, 9.8, 7.2, 6.1),
			    new Car("MNO-345", "Mercedes", "C-Class", 156, "Fekete", 11800000, 9.5, 7.0, 6.0),
			    new Car("PQR-678", "Audi", "A4", 150, "Piros", 11200000, 9.2, 6.9, 5.9),
			    new Car("STU-901", "Skoda", "Octavia", 115, "Zöld", 5600000, 7.5, 6.2, 5.4),
			    new Car("VWX-234", "Ford", "Focus", 125, "Szürke", 4900000, 8.0, 6.6, 5.7),
			    new Car("YZA-567", "Renault", "Megane", 130, "Sárga", 4700000, 8.3, 6.9, 5.8),
			    new Car("BCD-890", "Hyundai", "i30", 120, "Fehér", 4400000, 7.8, 6.4, 5.5)
			};
            //Car testCar = inputData();

            //Console.WriteLine(testCar);
            CarFileManager.SaveDataToFile(fileName, pucuscars);
            cars = CarFileManager.ReadCarsFromBinaryFile(fileName);
			


			Console.WriteLine(cars[0]);
			//UserInterfaces.menu(fileName,cars);
            Console.ReadKey();

		}
	}
}