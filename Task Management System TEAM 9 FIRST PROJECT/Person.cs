using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Management_System
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static bool ValidateAge(int age)
        {
            if (age < 0 || age > 150)
            {
                Console.WriteLine("Invalid age! Age must be between 0 and 150.");
                return false;
            }
            return true;
        }

        public static Person FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            string name = values[0];
            int age;
            if (!int.TryParse(values[1], out age))
            {
                throw new InvalidDataException("Invalid data format! Age must be an integer.");
            }
            if (!ValidateAge(age))
            {
                throw new InvalidDataException("Invalid age value in CSV file.");
            }
            return new Person(name, age);
        }

        public override string ToString()
        {
            return $"{Name}, {Age}";
        }

        public static void SaveToFile(string path, Person person)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"{person.Name},{person.Age}");
            }
        }
    }
}
