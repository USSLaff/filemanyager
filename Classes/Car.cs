using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager.Classes
{
    public class Car
    {
        private string licensePlate;
        private string brand;
        private string name;
        private string color;
        private double price;
        private int horsePower;
        private double[] consumption = new double[3];
        private bool isEconomy;

      

        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                if (IsValidLicensePlate(value))
                {
                    licensePlate = value.ToUpper();
                }
                else
                {
                    throw new ArgumentException("Invalid license plate format. Valid formats: ABC-123 or AA-AA-123");
                }
            }
        }
        public int HorsePower{
            get { return horsePower; }
            set {
                if (value < 0)
                {
                    throw new Exception("Horse power can't be negative or is it a JUNK?");
                }
                    else { 
                        horsePower = value;
                    }
                }
            
            }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value;
            }
        }

        public double[] Consumption
        {
            get { return consumption; }
            set
            {
                if (value.Length != 3)
                {
                    throw new ArgumentException("Consumption array must contain exactly 3 values");
                }
                consumption = value;
                UpdateEconomyStatus();
            }
        }

        public bool IsEconomy
        {
            get { return isEconomy; }
        }

        public static bool IsValidLicensePlate(string plate)
        {
            if (string.IsNullOrEmpty(plate))
                return false;

            plate = plate.ToUpper();
            if (plate.Length == 7 && plate[3] == '-')
            {
                string firstPart = plate.Substring(0, 3);
                string secondPart = plate.Substring(4, 3);

                return secondPart.All(char.IsDigit) &&
                       firstPart.All(c => c >= 'A' && c <= 'Z');
            }

            if (plate.Length == 9 && plate[2] == '-' && plate[5] == '-')
            {
                string part1 = plate.Substring(0, 2);
                string part2 = plate.Substring(3, 2);
                string part3 = plate.Substring(6, 3);

                return part1.All(c => c >= 'A' && c <= 'Z') &&
                       part2.All(c => c >= 'A' && c <= 'Z') &&
                       part3.All(char.IsDigit);
            }

            return false;
        }

        
        public void SetConsumption(double city, double mixed, double highway)
        {
            if (city < 0 || mixed < 0 || highway < 0)
            {
                throw new ArgumentException("Consumption values cannot be negative");
            }

            consumption[0] = city;
            consumption[1] = mixed;
            consumption[2] = highway;
            UpdateEconomyStatus();
        }

        private void UpdateEconomyStatus()
        {
            isEconomy = consumption[1] <= 10; 
        }

        public double GetCityConsumption() => consumption[0];
        public double GetMixedConsumption() => consumption[1];
        public double GetHighwayConsumption() => consumption[2];


        public override string ToString()
        {
            return $"\nLicense plate: {licensePlate}\nBrand: {brand}\nName: {name}\nColor: {Color}\nHorse Power: {horsePower}\nPrice: {price} HUF\nConsumption: \n\tCity: {consumption[0]} L/100Km\n\tMixed: {consumption[1]} L/100Km\n\tHighway: {consumption[2]} L/100Km\nEconomy: {(isEconomy ? "Cheap":"Expensive")}";
        }

        public Car()
        {
        }
        public Car(string licensePlate, string brand, string name, int horsepower, string color, double price, double cityConsumption, double mixedConsumption, double highwayConsumption)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Name = name;
            HorsePower = horsepower;
            Color = color;
            Price = price;
            SetConsumption(cityConsumption, mixedConsumption, highwayConsumption);
        }
    }
}