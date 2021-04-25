using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct User
    {
        public string name;
        public int age;
        public User(string name, int age)
        {
            this.age = age;
            this.name = name;
        }
        public int IncremAge()
        {
            age++;
            return age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User a;
            a.age = 5;
            a.name = "John";
            Console.WriteLine(a.age);
            a.IncremAge();
            Console.WriteLine(a.age);
        }
    }
}
