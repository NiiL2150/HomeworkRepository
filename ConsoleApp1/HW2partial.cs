using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class SpaceShip
    {
        public override string ToString()
        {
            return $"Title: {title}\nBuilt year: {builtYear}\nOil type: {oilType}\n" +
                $"Oil capacity: {oilCapacity}\nCargo capacity: {CargoCapacity}\nPeople in space: {peopleInSpace}\n";
        }
        public void Print()
        {
            Console.Write(this);
        }
        public void PrintLatestLaunch()
        {
            Console.Write(latestLaunch);
        }
    }
}
