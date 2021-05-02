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
        public static Point operator -(Point z1, Point z2)
        {
            return new Point(z1.X - z2.X, z1.Y - z2.Y);
        }
        public override string ToString()
        {
            return $"x = {X} y = {Y}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(3, 3), p2 = new Point(2, 2);
            Console.WriteLine(p - p2);
        }
    }
}
