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
            Console.WriteLine(p == "x = 1 y = 1");
        }
    }
}
