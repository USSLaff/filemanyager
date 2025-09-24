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
        public static void DeleteByLicensePlate(string licensePlate, string fileName)
        {
            List<Car> cars = new List<Car>();

            using (var stream = File.Open(fileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    cars = (List<Car>)formatter.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba történt a fájl deszerializálása közben: " + ex.Message);
                    return;
                }

                Car asd = cars.FirstOrDefault(x => x.LicensePlate == licensePlate);
                if (asd.LicensePlate == licensePlate)
                {

                    cars.RemoveAll(car => car.LicensePlate == licensePlate);
                }

                
            }

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(stream, cars);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba történt a fájl szérializálása közben: " + ex.Message);
                }
            }

            Console.WriteLine($"A(z) {licensePlate} rendszámú autó törlésre került.");
        }
    }
}
