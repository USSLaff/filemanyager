using file_manager.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using file_manager.Classes;

namespace file_manager.Methods
{
    public class CarFileManager
    {
        public List<Car> ReadCarsFromBinaryFile(string filePath)
        {
            List<Car> cars = new List<Car>();

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            long fileLength = new FileInfo(filePath).Length;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
            {
                for (long position = 0; position < fileLength;)
                {
                    try
                    {
                        string licensePlate = reader.ReadString();
                        string brand = reader.ReadString();
                        string name = reader.ReadString();
                        string color = reader.ReadString();
                        double price = reader.ReadDouble();
                        int horsePower = reader.ReadInt32();
                        double cityConsumption = reader.ReadDouble();
                        double mixedConsumption = reader.ReadDouble();
                        double highwayConsumption = reader.ReadDouble();

                        Car car = new Car(licensePlate, brand, name, horsePower, color, price,
                                        cityConsumption, mixedConsumption, highwayConsumption);

                        cars.Add(car);

                        position = fs.Position;
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error due read: {ex.Message}");
                        break;
                    }
                }
            }

            return cars;
        }
    }
}