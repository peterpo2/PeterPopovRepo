using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemo
{
    public class Person
    {
        private int age;
        public Person(int age) 
        {
            this.Age = age;
        }
        public int Age 
        {
            get { return this.age; } 
            set 
            {
                if (value < 0 || value > 150) 
                {
                    throw new InvalidUserInputException("Age must be between 0 and 150 years");
                }
                this.age = value;
            } 
        }
    }
}
