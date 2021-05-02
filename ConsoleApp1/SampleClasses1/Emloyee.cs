using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.SampleClasses1
{
    abstract class Emloyee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Emloyee(string fullName, string position, double salary)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Full name: {FullName}\nPosition: {Position}\nSalary: {Salary}\n";
        }
    }
}
