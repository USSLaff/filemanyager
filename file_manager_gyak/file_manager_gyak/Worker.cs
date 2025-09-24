using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_manager_gyak
{
    [Serializable]
    internal class Worker
    {
        private string code;
        private string name;
        private string birthDate;
        private string salary;

        public Worker(string code, string name, string birthDate, string salary)
        {
            if (!ValidateCode(code))
                throw new ArgumentException("Code must be max 3 digits");

            if (!ValidateName(name))
                throw new ArgumentException("Name must be max 30 characters");

            if (!ValidateBirthDate(birthDate))
                throw new ArgumentException("Birth date must be in valid format");

            if (!ValidateSalary(salary))
                throw new ArgumentException("Salary must be min 7 digits");

            this.code = code;
            this.name = name;
            this.birthDate = birthDate;
            this.salary = salary;
        }

        public static bool ValidateCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length > 3)
                return false;

            foreach (char c in code)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public static bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length <= 30;
        }

        public static bool ValidateBirthDate(string birthDate)
        {
            if (string.IsNullOrEmpty(birthDate))
                return false;

            return DateTime.TryParse(birthDate, out DateTime result);
        }

        public static bool ValidateSalary(string salary)
        {
            if (string.IsNullOrEmpty(salary) || salary.Length < 7)
                return false;

            foreach (char c in salary)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public string GetCode() => code;
        public string GetName() => name;
        public string GetBirthDate() => birthDate;
        public string GetSalary() => salary;

        public override string ToString()
        {
            return $"Code: {code}, Name: {name}, BirthDate: {birthDate}, Salary: {salary}";
        }
    }
}
