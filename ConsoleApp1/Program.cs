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
    class Calc
    {
        static public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        static public int Mult(int n1, int n2)
        {
            return n1 * n2;
        }
    }

    class Program
    {
        public static dynamic DCast(dynamic source, Type type)
        {
            return Convert.ChangeType(source, type);
        }

        static void Main(string[] args)
        {
            Calc math = new Calc();
            string read = Console.ReadLine();
            foreach (System.Reflection.MethodInfo item in math.GetType().GetMethods())
            {
                if(String.Compare(item.Name.ToLower(), 0, read.ToLower(), 0, Math.Min(item.Name.Length, read.Length)) == 0)
                {
                    Console.Clear();
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.GetParameters().Length);
                    object[] vs = new object[item.GetParameters().Length];
                    for (int i = 0; i<vs.Length; i++)
                    {
                        Console.Write($"{item.GetParameters()[i].Name} - {item.GetParameters()[i].ParameterType.Name} - ");
                        vs[i] = (DCast(Console.ReadLine(), item.GetParameters()[i].ParameterType));
                    }
                    Console.WriteLine(item.Invoke(math, vs));
                    break;
                }
            }
        }
    }
}
