using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tank
    {
        #region ClassObjects
        private string tankTitle;
        private int damageLVL;
        private int defenceLVL;
        private int speedLVL;
        private static Random random;
        #endregion

        #region StringGetters
        public string GetTankTitle()
        {
            return tankTitle;
        }
        public string GetDamageLVL()
        {
            return Convert.ToString(damageLVL);
        }
        public string GetDefenceLVL()
        {
            return Convert.ToString(defenceLVL);
        }
        public string GetSpeedLVL()
        {
            return Convert.ToString(speedLVL);
        }
        #endregion

        #region Constructors
        private Tank(string _title, int _damageLVL, int _defenceLVL, int _speedLVL)
        {
            if (_damageLVL > 100 || _damageLVL < 0 || _defenceLVL > 100 || _defenceLVL < 0 || _speedLVL > 100 || _speedLVL < 0)
            {
                throw new Exception("All of the parameters must be ranged from 0 to 100 inclusively");
            }
            tankTitle = _title;
            damageLVL = _damageLVL;
            defenceLVL = _defenceLVL;
            speedLVL = _speedLVL;
        }
        public Tank(string _title) : this(_title, 0, 0, 0)
        {
            damageLVL = random.Next(101);
            defenceLVL = random.Next(101);
            speedLVL = random.Next(101);
        }
        static Tank()
        {
            random = new Random();
        }
        #endregion

        #region OperatorOverload
        public static Tank operator *(Tank a, Tank b)
        {
            int score = 0;
            if (a.damageLVL > b.damageLVL) { score++; }
            if (a.defenceLVL > b.defenceLVL) { score++; }
            if(a.speedLVL > b.speedLVL) { score++; }
            if (score > 1) { return a; }
            else { return b; }
        }
        #endregion

        #region PrintMethods
        public void Print()
        {
            Console.WriteLine($"Title: {tankTitle}");
            Console.WriteLine($"Level of damage: {damageLVL}");
            Console.WriteLine($"Level of defence: {defenceLVL}");
            Console.WriteLine($"Level of speed: {speedLVL}");
        }
        #endregion
    }
    class Battle
    {
        #region ClassObjects
        private Tank[] T34;
        private Tank[] Pantera;
        #endregion

        #region Constructor
        public Battle()
        {
            T34 = new Tank[5];
            Pantera = new Tank[5];
            for (int i = 0; i < 5; i++)
            {
                T34[i] = new Tank($"T34 #{i + 1}");
                Pantera[i] = new Tank($"Pantera #{i + 1}");
            }
        }
        #endregion

        #region PrintMethods
        public void PrintT34(int place)
        {
            T34[place].Print();
        }
        public void PrintPantera(int place)
        {
            Pantera[place].Print();
        }
        public void PrintT34()
        {
            for (int i = 0; i < 5; i++)
            {
                PrintT34(i);
                Console.WriteLine();
            }
        }
        public void PrintPantera()
        {
            for (int i = 0; i < 5; i++)
            {
                PrintPantera(i);
                Console.WriteLine();
            }
        }
        public void PrintResult()
        {
            int score = 0;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1} round winner is:");
                Tank winner = T34[i] * Pantera[i];
                winner.Print();
                Console.WriteLine();
                if(winner == T34[i])
                {
                    score++;
                }
            }
            if (score > 2)
            {
                Console.WriteLine("T34 team won!");
            }
            else
            {
                Console.WriteLine("Pantera team won!");
            }
        }
        #endregion
    }
    class HW3
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            battle.PrintT34();
            Console.WriteLine();
            battle.PrintPantera();
            Console.ReadKey();
            battle.PrintResult();
        }
    }
}
