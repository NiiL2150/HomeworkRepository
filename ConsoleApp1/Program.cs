using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using ConsoleApp1.SampleClasses1;
using ConsoleApp1.SampleClasses1.Interfaces;

namespace ConsoleApp1
{
    class GCHelper
    {
        public void MakeGarbage()
        {
            Console.WriteLine("Making garbage");
            for (int i = 0; i < 10; i++)
            {
                Person p = new Person();
            }
        }
        class Person
        {
            string name;
            int age;
        }
    }

    class FinilizeExample
    {
        int id;
        public FinilizeExample(int id)
        {
            this.id = id;
        }
        ~FinilizeExample()
        {
            Console.WriteLine($"Finilize! {id}");
        }
    }

    class DisposeExample : IDisposable
    {
        bool isDisposed = false;

        void Clearing(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Clear managed resources");
                }
                Console.WriteLine("Clear unmanaged resources");
            }
            isDisposed = true;
        }
        public void Dispose()
        {
            Clearing(true);
            GC.SuppressFinalize(this);
        }
        public void DoSome()
        {
            Console.WriteLine("Do some");
        }
        ~DisposeExample()
        {
            Clearing(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using(DisposeExample dispose = new DisposeExample())
            {
                dispose.DoSome();
            }

            int a = 5;
            int b = Int32.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(a / b);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
