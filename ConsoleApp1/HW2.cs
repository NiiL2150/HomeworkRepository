using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class SpaceShip
    {
        #region ClassFieldsMethodsProps
        private int builtYear;
        public int GetBuiltYear()
        {
            return builtYear;
        }
        public void SetBuiltYear(int _builtYear)
        {
            builtYear = _builtYear;
        }

        private string title;
        public string Title { get => title; set => title = value; }

        private string oilType;
        public string GetOilType()
        {
            return oilType;
        }
        public void SetOilType(string _oilType)
        {
            oilType = _oilType;
        }

        private int oilCapacity;
        public int OilCapacity
        {
            get
            {
                return oilCapacity;
            }
            set
            {
                oilCapacity = value;
            }
        }

        public int CargoCapacity { get; set; }

        private static int peopleInSpace;
        public int GetPeopleInSpace()
        {
            return peopleInSpace;
        }
        public void SetPeopleInSpace(int _peopleInSpace)
        {
            peopleInSpace = _peopleInSpace;
        }

        private static SpaceShip latestLaunch;
        public SpaceShip LatestLaunch { get => latestLaunch; set => latestLaunch = value; }
        #endregion
        #region ctors
        public SpaceShip(ref SpaceShip spaceShip, bool isLaunched)
        {
            this.builtYear = spaceShip.builtYear;
            this.oilCapacity = spaceShip.oilCapacity;
            this.oilType = spaceShip.oilType;
            this.title = spaceShip.title;
            this.CargoCapacity = spaceShip.CargoCapacity;
            if (isLaunched)
            {
                this.LatestLaunch = this;
            }
        }
        public SpaceShip(string _title, int _builtYear, string _oilType, int _oilCapacity, int _CargoCapacity)
        {
            this.builtYear = _builtYear;
            this.oilCapacity = _oilCapacity;
            this.oilType = _oilType;
            this.title = _title;
            this.CargoCapacity = _CargoCapacity;
        }
        public SpaceShip(string _title, int _builtYear)
        {
            this.builtYear = _builtYear;
            this.oilCapacity = 0;
            this.oilType = "Declassified";
            this.title = _title;
            this.CargoCapacity = 0;
        }
        public SpaceShip(string _title) : this(_title, 2021) { }
        public SpaceShip() : this("Untitled") { }
        static SpaceShip()
        {
            peopleInSpace = 0;
            latestLaunch = null;
        }
        #endregion
    }
    class HW2
    {
        /*
        static void Main(string[] args)
        {
            SpaceShip spaceShip = new SpaceShip("SpaceX Starship 2020", 2020, "Methane", 3300, 5000);
            SpaceShip[] spaceShips = new SpaceShip[5]
            {
                new SpaceShip(),
                new SpaceShip("Chinese Spaceship"),
                new SpaceShip("SpaceX Falcon Heavy", 2018),
                new SpaceShip("SpaceX Starship", 2012, "Methane", 3300, 5000),
                new SpaceShip(ref spaceShip, true)
            };

            Console.WriteLine("Test 1");
            foreach (var item in spaceShips)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            spaceShip.SetPeopleInSpace(spaceShip.GetPeopleInSpace() + 1);

            Console.WriteLine("Test 2");
            foreach (var item in spaceShips)
            {
                item.Print();
                Console.WriteLine();
            }

            Console.WriteLine("Test 3");
            spaceShip.PrintLatestLaunch();
            Console.WriteLine();
            spaceShip.LatestLaunch = spaceShips[3];
            spaceShip.PrintLatestLaunch();
            Console.WriteLine();
        }*/
    }
}
