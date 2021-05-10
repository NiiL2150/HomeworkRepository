using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.SampleClasses1;
using ConsoleApp1.SampleClasses1.Interfaces;

namespace ConsoleApp1
{
    class Bank<T>
    {
        public T BankNumber { get; set; }
        public Bank(T bankNumber)
        {
            BankNumber = bankNumber;
        }
        public override string ToString()
        {
            return $"{BankNumber}";
        }
    }
    class Program
    {
        /*static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            ArrayList arrayList = new ArrayList { 1, 2, 3, "List" };
            LinkedList<int> vs = new LinkedList<int>();
            vs.AddLast(1);
            vs.AddLast(2);
            vs.AddLast(3);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }

            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Kanan");
            hashtable.Add(5.12f, "Nurana");
            hashtable.Add('c', "Rashvin");
            Console.WriteLine();

            Dictionary<string, int> kV = new Dictionary<string, int>();
            kV.Add("Javid", 10);
            kV.Add("Kanan", 25);
            Console.WriteLine("Keys");
            foreach (var item in kV.Keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Dictionary");
            foreach (var item in kV)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }*/
    }
}
