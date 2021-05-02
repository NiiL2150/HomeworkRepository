using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bank
    {
        public static int balance;
        public int localBalance;
        public readonly string birthday;

        public Bank()
        {
            localBalance = 0;
            birthday = "31/10/1998";
        }
        public Bank(int localBalance)
        {
            birthday = "31/10/1998";
            balance += localBalance;
            this.localBalance = localBalance;
        }
        static Bank()
        {
            balance = 10;
        }
        public static void AddGeneralBalance(int amount)
        {
            balance += amount;
        }
        public void AddLocalBalance(int amount)
        {
            localBalance += amount;
            balance += amount;
        }
        public void Print()
        {
            Console.WriteLine($"Local balance of branch: {localBalance} manat\n" +
                $"Total balance of all branch: {balance} manat");
        }
    }
    partial class MyClass
    {
        private int age;
        public int Age { get => age; set => age = value; }

        public MyClass()
        {

        }
        public static int Sum(params int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
    class Program
    {
        /*static void Main(string[] args)
        {

        }*/
    }
}
