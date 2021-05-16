using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /*static void Main(string[] args)
        {
            int a = 2;
            int b = Int32.Parse(Console.ReadLine());
            try
            {
                //a = a / b;
                Console.WriteLine(a / b);
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"a = {a} b = {b}  Exception data:{ex.Message} \n exception stack trace: \n {ex.StackTrace}");
                MessageBox.Show("Connection lost unhandled exception something went wrong", "Divizion by zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("!!!!!!!!!!!" + ex.Message);
            }
        }*/
    }
}
