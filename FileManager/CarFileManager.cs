using file_manager.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.FileManager
{
    public class CarFileManager
    {
        public static List<Car> ReadCarsFromBinaryFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                try
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, new List<Car>());
                    }
                    Console.WriteLine($"File created: {filePath}");
                    return new List<Car>();
                }
                catch (Exception createEx)
                {
                    Console.WriteLine($"Error creating file: {createEx.Message}");
                    return new List<Car>();
                }
            }
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    return (List<Car>)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return new List<Car>();
            }
        }

        public static void SaveDataToFile(string fileName, List<Car> cars)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    formatter.Serialize(stream, cars);
                }
                Console.WriteLine("Cars loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }
    }
}