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
		




		public static void SortOptions(int opt)
		{
			//wip xddd

			return;

		}
		static void Main(string[] args)
		{
			//WriteToFile();
			DisplayValues();
			//Car testCar = new Car("IAP-512","Ford","Focus Mk1",75,"Gray",879000,7.6,6.3,5.5);
			//Car testCar = inputData();
			
			//Console.WriteLine(testCar);
            UserInterfaces.menu();
            Console.ReadKey();

		}
	}
}