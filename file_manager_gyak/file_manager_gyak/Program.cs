using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace file_manager_gyak
{

    internal class Program
    {
        private static List<Worker> workers = new List<Worker>();
        private const string DataFile = "workers.dat";

        static void Main()
        {
            LoadWorkersFromFile();

            while (true)
            {
                Console.Clear();
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWorker();
                        break;
                    case "2":
                        ListWorkers();
                        break;
                    case "3":
                        SaveWorkersToFile();
                        Console.WriteLine("Workers saved to file. Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n=== Worker Management System ===");
            Console.WriteLine("1. Add new worker");
            Console.WriteLine("2. List all workers");
            Console.WriteLine("3. Save and exit");
            Console.Write("Choose an option: ");
        }

        static void AddWorker()
        {
            try
            {
                string code = GetValidatedInput("Enter worker code (max 3 digits): ", Worker.ValidateCode);

                if (IsCodeExists(code))
                {
                    Console.WriteLine($"Error: Worker with code '{code}' already exists!");
                    return;
                }

                string name = GetValidatedInput("Enter worker name (max 30 characters): ", Worker.ValidateName);
                string birthDate = GetValidatedInput("Enter birth date: ", Worker.ValidateBirthDate);
                string salary = GetValidatedInput("Enter salary (min 7 digits): ", Worker.ValidateSalary);

                Worker worker = new Worker(code, name, birthDate, salary);
                workers.Add(worker);
                Console.WriteLine("Worker added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static bool IsCodeExists(string code)
        {
            return workers.Any(worker => worker.GetCode() == code);
        }

        static void ListWorkers()
        {
            if (workers.Count == 0)
            {
                Console.WriteLine("No workers in the list.");
                return;
            }

            Console.WriteLine("\n=== Worker List ===");
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {workers[i]}");
            }
        }

        static string GetValidatedInput(string prompt, Func<string, bool> validator)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (!validator(input))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

            } while (!validator(input));

            return input;
        }

        static void SaveWorkersToFile()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(DataFile, FileMode.Create))
                {
                    formatter.Serialize(stream, workers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        static void LoadWorkersFromFile()
        {
            try
            {
                if (File.Exists(DataFile))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream stream = new FileStream(DataFile, FileMode.Open))
                    {
                        workers = (List<Worker>)formatter.Deserialize(stream);
                    }
                    Console.WriteLine($"Loaded {workers.Count} workers from file.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No existing data file found. Starting with empty list.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
                Console.WriteLine("Starting with empty list.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                workers = new List<Worker>();
            }
        }
    }
}
