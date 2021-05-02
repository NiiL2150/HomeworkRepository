using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.SampleClasses1.Interfaces;

namespace ConsoleApp1.SampleClasses1
{
    class Worker: Emloyee, IWorking
    {
        public Worker(string fullName, string position, double salary) : base(fullName, position, salary) { }
        public bool IsWork { get; set; }
        public void DoSomething()
        {
            Console.WriteLine("Working");
        }
    }
}
