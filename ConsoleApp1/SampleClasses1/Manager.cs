using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.SampleClasses1.Interfaces; 

namespace ConsoleApp1.SampleClasses1
{
    class Manager : Emloyee, IManaging
    {
        public List<IWorking> Workers { get; set; }
        public Manager(string fullName, string position, double salary) : base(fullName, position, salary)
        {
            Workers = new List<IWorking>();
        }
        public void Manage()
        {
            Console.WriteLine("Managing...");
        }
        public void Organise()
        {
            Console.WriteLine("Organising...");
        }
        public void Control()
        {
            Console.WriteLine("Controlling...");
        }
    }
}
