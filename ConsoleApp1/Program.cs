using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public class PropertyEventArgs<T>
    {
        public string propName;
        public bool isSuccess;
        public T value;
        static public int changeCount;
        static public int successfulCount;
        public PropertyEventArgs(string name, bool success, T value)
        {
            this.value = value;
            propName = name;
            isSuccess = success;
            changeCount++;
            if (success)
            {
                successfulCount++;
            }
        }
    }
    public delegate void PropertyEventHandler(object sender, PropertyEventArgs<int> e);
    interface IPropertyChanged
    {
        event PropertyEventHandler PropertyChanged;
    }
    class MyClass : IPropertyChanged
    {
        public event PropertyEventHandler PropertyChanged;
        private int myInt;
        public int MyProperty
        {
            get
            {
                return myInt;
            }
            set
            {
                    try
                    {
                        if (value < 0)
                        {
                            throw new Exception();
                        }
                        myInt = value;
                        PropertyChanged?.Invoke(this, new PropertyEventArgs<int>("myInt", true, value));
                    }
                    catch (Exception)
                    {
                        PropertyChanged?.Invoke(this, new PropertyEventArgs<int>("myInt", false, value));
                    }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.PropertyChanged += ConsolePrint;
            myClass.MyProperty = 1;
            myClass.MyProperty = 5;
            myClass.MyProperty = -5;
        }

        static void ConsolePrint(object sender, PropertyEventArgs<int> e)
        {
            if (e.isSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{e.propName} changed for the (successful) {PropertyEventArgs<int>.successfulCount}/{PropertyEventArgs<int>.changeCount} (all) time to {e.value} in my class.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.propName} tried to be changed for the (successful) {PropertyEventArgs<int>.successfulCount}/{PropertyEventArgs<int>.changeCount} (all) time from {(sender as MyClass).MyProperty} to {e.value} in my class.");
            }
            Console.ResetColor();
        }
    }
}
