using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConsoleApp1
{
    class User
    {
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}; Age: {Age};");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Admin", 56);
            Console.WriteLine(typeof(User));
            Console.WriteLine(user.GetType());
            Console.WriteLine(Type.GetType("ConsoleApp1.User", false, true));
        }
    }
}
