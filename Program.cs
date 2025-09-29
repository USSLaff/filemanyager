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
       
        static void Main(string[] args)
		{
			UserInterfaces.menu(fileName);
		}
	}
}