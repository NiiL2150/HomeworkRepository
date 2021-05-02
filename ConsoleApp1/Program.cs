using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.SampleClasses1;
using ConsoleApp1.SampleClasses1.Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IManaging manager = new Manager("Nail", "Cool guy", 10000);
            manager.Workers.Add(new Worker("Nail2", "Another cool guy", 1000));
            manager.Workers.Add(new Worker("Nail3", "Yet another cool guy", 100));
            manager.Workers.Add(new Worker("Nail4", "Yet yet another cool guy", 10));
            foreach (IWorking item in manager.Workers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
