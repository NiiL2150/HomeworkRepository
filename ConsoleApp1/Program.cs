using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Point operator ++(Point z)
        {
            z.X++;
            z.Y++;
            return z;
        }
        public static Point operator +(Point z1, Point z2)
        {
            return new Point(z1.X + z2.X, z1.Y + z2.Y);
        }
        public static Point operator +(Point z2, int pos)
        {
            return new Point(pos + z2.X, pos + z2.Y);
        }
        public static Point operator -(Point z1, Point z2)
        {
            return new Point(z1.X - z2.X, z1.Y - z2.Y);
        }
        public static Point operator -(Point z2, int pos)
        {
            return new Point(z2.X - pos, z2.Y - pos);
        }
        public override string ToString()
        {
            return $"x = {X} y = {Y}";
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return (this.ToString() == obj.ToString());
        }
        public static bool operator ==(Point z1, Point z2)
        {
            return (z1.Equals(z2));
        }
        public static bool operator !=(Point z1, Point z2)
        {
            return !(z1.Equals(z2));
        }
    }
    class City
    {
        public string Name { get; set; }
        public City(string _name)
        {
            Name = _name;
        }
    }
    class Country
    {
        City[] cities;
        public int Count { get => cities.Length; }
        public string Name { get; set; }
        public Country(string name, int count)
        {
            Name = name;
            cities = new City[count];
        }
        public City this[int index]
        {
            get
            {
                return cities[index];
            }
            set
            {
                cities[index] = value;
            }
        }
        public static explicit operator string(Country c)
        {
            return c.Name;
        }
        public static implicit operator Country(string s)
        {
            return new Country(s, 0);
        }
        public override string ToString()
        {
            string tmpStr = $"=========={Name}==========\n";
            for (int i = 0; i < cities.Length; i++)
            {
                tmpStr += $"{i + 1}. {cities[i].Name}\n";
            }
            return tmpStr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(3, 3), p2 = new Point(2, 2), p3 = new Point(1, 1);
            Console.WriteLine(p - p2);
            Console.WriteLine(p + 4);
            Console.WriteLine(p += 4);
            Console.WriteLine(p);
            Console.WriteLine(p -= 6);
            Console.WriteLine(p);
            Console.WriteLine(p.Equals(p3));
            Console.WriteLine(p == p3);
            Console.WriteLine(p != p3);
            Console.WriteLine(p.Equals("x = 1 y = 1"));

            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            Country country = new Country("Azerbaijan", 4);
            country[0] = new City("Baku");
            country[1] = new City("Ganja");
            country[2] = new City("Sumgait");
            country[3] = new City("Shamahi");
            Console.WriteLine(country);
        }
    }
}
