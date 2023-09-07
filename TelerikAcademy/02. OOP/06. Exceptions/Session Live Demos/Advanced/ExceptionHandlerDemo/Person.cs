using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlerDemo
{
    internal class Person
    {
        private int age;
        private string name;
        public Person(int age, string name) 
        {
            this.Age= age;
            this.Name = name;
        }

        public int Age
        {
            get { return this.age; }
            set 
            { 
                if(value<0||value>150) 
                {
                    throw new ArgumentOutOfRangeException("Invalid age");
                }
                this.age = value; 
            }
        }

        public string Name 
        {
            get { return this.name; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = value;
            }
        }

    }
}
