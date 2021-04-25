using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            /*
            char tmp;
            int numberOfSpaces = 0;
            while (true)
            {
                tmp = Convert.ToChar(Console.Read());
                if (tmp == '.')
                {
                    break;
                }
                else if (tmp == ' ')
                {
                    numberOfSpaces++;
                }
            }
            Console.WriteLine(numberOfSpaces);
            */

            //2
            /*
            int firstThree = 0, secondThree = 0;
            for (int i = 0; i < 3; i++)
            {
                firstThree += Convert.ToInt32(Console.Read());
            }
            for (int i = 0; i < 3; i++)
            {
                secondThree += Convert.ToInt32(Console.Read());
            }
            if (firstThree == secondThree)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            */

            //3
            /*
            string str1, str2 = "";
            str1 = Console.ReadLine();
            for (int i = 0; i < str1.Length; i++)
            {
                if (Char.IsLetter(str1, i))
                {
                    if(Char.IsUpper(str1, i))
                    {
                        str2 += Convert.ToChar(str1[i] + 32);
                    }
                    else
                    {
                        str2 += Convert.ToChar(str1[i] - 32);
                    }
                }
                else
                {
                    str2 += str1[i];
                }
            }
            Console.WriteLine(str2);
            */

            //4
            /*
            int numberA, numberB, numberOfSpaces;
            numberA = Int32.Parse(Console.ReadLine());
            numberB = Int32.Parse(Console.ReadLine());
            numberOfSpaces = Convert.ToInt32(System.Math.Log10(Convert.ToDouble(numberB))) + 2;
            for (int i = numberA; i <= numberB; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(Convert.ToString(i).PadRight(numberOfSpaces, ' '));
                }
                Console.WriteLine();
            }
            */

            //5
            /*
            int numberOne = Int32.Parse(Console.ReadLine());
            char[] charArray = (Convert.ToString(numberOne)).ToCharArray();
            Array.Reverse(charArray);
            string tmpStr = new string(charArray);
            int numberTwo = Convert.ToInt32(tmpStr);
            Console.WriteLine(numberTwo);
            */
        }
    }
}
