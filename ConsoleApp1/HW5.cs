using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IWorker
    {
        int PowerPerWork { get; set; }
        bool IsWorking { get; set; }
        bool CheckPart(IPart part);
    }
    class Worker : IWorker
    {
        public int PowerPerWork { get; set; }
        public bool IsWorking { get; set; }
        public bool CheckPart(IPart part)
        {
            if (part.CheckBuild())
            {
                IsWorking = false;
                return false;
            }
            else
            {
                int power = 0;
                foreach (var item in part.Workers)
                {
                    power += item.PowerPerWork;
                }
                if (power < (part.BuildTime - part.AlreadyBuild))
                {
                    IsWorking = true;
                    return true;
                }
                else
                {
                    IsWorking = false;
                    return false;
                }
            }
        }
        public Worker(int powerPerWork, bool isWorking)
        {
            PowerPerWork = powerPerWork;
            IsWorking = isWorking;
        }
        public Worker(int powerPerWork) : this(powerPerWork, false) { }
        public Worker() : this(10) { }
    }
    class TeamLeader
    {
        public Home BuildingHome { get; set; }
        public void PrintHome()
        {
            Console.WriteLine($"Roof:     {BuildingHome.HomeRoof.AlreadyBuild * 100 / BuildingHome.HomeRoof.BuildTime}        Workers - {BuildingHome.HomeRoof.Workers.Count}");

            Console.WriteLine($"Door:     {BuildingHome.MainDoor.AlreadyBuild * 100 / BuildingHome.MainDoor.BuildTime}        Workers - {BuildingHome.MainDoor.Workers.Count}");
            Console.WriteLine($"Window 4: {BuildingHome.MainParts[3, 1].AlreadyBuild * 100 / BuildingHome.MainParts[3, 1].BuildTime}        Workers - {BuildingHome.MainParts[3, 1].Workers.Count}");
            Console.WriteLine($"Wall 4:   {BuildingHome.MainParts[3, 0].AlreadyBuild * 100 / BuildingHome.MainParts[3, 0].BuildTime}        Workers - {BuildingHome.MainParts[3, 0].Workers.Count}");
            Console.WriteLine($"Window 3: {BuildingHome.MainParts[2, 1].AlreadyBuild * 100 / BuildingHome.MainParts[2, 1].BuildTime}        Workers - {BuildingHome.MainParts[2, 1].Workers.Count}");
            Console.WriteLine($"Wall 3:   {BuildingHome.MainParts[2, 0].AlreadyBuild * 100 / BuildingHome.MainParts[2, 0].BuildTime}        Workers - {BuildingHome.MainParts[2, 0].Workers.Count}");
            Console.WriteLine($"Window 2: {BuildingHome.MainParts[1, 1].AlreadyBuild * 100 / BuildingHome.MainParts[1, 1].BuildTime}        Workers - {BuildingHome.MainParts[1, 1].Workers.Count}");
            Console.WriteLine($"Wall 2:   {BuildingHome.MainParts[1, 0].AlreadyBuild * 100 / BuildingHome.MainParts[1, 0].BuildTime}        Workers - {BuildingHome.MainParts[1, 0].Workers.Count}");
            Console.WriteLine($"Window 1: {BuildingHome.MainParts[0, 1].AlreadyBuild * 100 / BuildingHome.MainParts[0, 1].BuildTime}        Workers - {BuildingHome.MainParts[0, 1].Workers.Count}");
            Console.WriteLine($"Wall 1:   {BuildingHome.MainParts[0, 0].AlreadyBuild * 100 / BuildingHome.MainParts[0, 0].BuildTime}        Workers - {BuildingHome.MainParts[0, 0].Workers.Count}");

            Console.WriteLine($"Basement: {BuildingHome.HomeBasement.AlreadyBuild * 100 / BuildingHome.HomeBasement.BuildTime}        Workers - {BuildingHome.HomeBasement.Workers.Count}");
        }
        public TeamLeader(Home home)
        {
            BuildingHome = home;
        }
    }
    class Team
    {
        public IWorker[] Workers { get; set; }
        public TeamLeader Leader { get; set; }
        public Team(int quantity, Home home)
        {
            Workers = new IWorker[quantity];
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine($"{i + 1} worker:");
                Console.Write($"Power per work: ");
                int tempPPW = Int32.Parse(Console.ReadLine());
                Workers[i] = new Worker(tempPPW);
            }
            Leader = new TeamLeader(home);
        }
        public IWorker this[int worker]
        {
            get
            {
                return Workers[worker];
            }
        }
    }
    #region Parts
    interface IPart
    {
        int BuildTime { get; set; }
        int AlreadyBuild { get; set; }
        bool CheckBuild();
        List<IWorker> Workers { get; set; }
        void ClearWorkers();
        void Work();
    }
    class Basement : IPart
    {
        public int BuildTime { get; set; }
        public int AlreadyBuild { get; set; }
        public List<IWorker> Workers { get; set; }
        public bool CheckBuild()
        {
            return (AlreadyBuild >= BuildTime);
        }
        public void ClearWorkers()
        {
            Workers.Clear();
        }
        public void Work()
        {
            foreach (var item in Workers)
            {
                AlreadyBuild += item.PowerPerWork;
            }
        }
        public Basement(int buildTime)
        {
            BuildTime = buildTime;
            AlreadyBuild = 0;
            Workers = new List<IWorker>();
        }
        public Basement() : this(400) { }
    }
    class Wall : IPart
    {
        public int BuildTime { get; set; }
        public int AlreadyBuild { get; set; }
        public List<IWorker> Workers { get; set; }
        public bool CheckBuild()
        {
            return (AlreadyBuild >= BuildTime);
        }
        public void ClearWorkers()
        {
            Workers.Clear();
        }
        public void Work()
        {
            foreach (var item in Workers)
            {
                AlreadyBuild += item.PowerPerWork;
            }
        }
        public Wall(int buildTime)
        {
            BuildTime = buildTime;
            AlreadyBuild = 0;
            Workers = new List<IWorker>();
        }
        public Wall() : this(200) { }
    }
    class Door : IPart
    {
        public int BuildTime { get; set; }
        public int AlreadyBuild { get; set; }
        public List<IWorker> Workers { get; set; }
        public bool CheckBuild()
        {
            return (AlreadyBuild >= BuildTime);
        }
        public void Work()
        {
            foreach (var item in Workers)
            {
                AlreadyBuild += item.PowerPerWork;
            }
        }
        public void ClearWorkers()
        {
            Workers.Clear();
        }
        public Door(int buildTime)
        {
            BuildTime = buildTime;
            AlreadyBuild = 0;
            Workers = new List<IWorker>();
        }
        public Door() : this(100) { }
    }
    class Window : IPart
    {
        public int BuildTime { get; set; }
        public int AlreadyBuild { get; set; }
        public List<IWorker> Workers { get; set; }
        public bool CheckBuild()
        {
            return (AlreadyBuild >= BuildTime);
        }
        public void ClearWorkers()
        {
            Workers.Clear();
        }
        public void Work()
        {
            foreach (var item in Workers)
            {
                AlreadyBuild += item.PowerPerWork;
            }
        }
        public Window(int buildTime)
        {
            BuildTime = buildTime;
            AlreadyBuild = 0;
            Workers = new List<IWorker>();
        }
        public Window() : this(50) { }
    }
    class Roof : IPart
    {
        public int BuildTime { get; set; }
        public int AlreadyBuild { get; set; }
        public List<IWorker> Workers { get; set; }
        public bool CheckBuild()
        {
            return (AlreadyBuild >= BuildTime);
        }
        public void ClearWorkers()
        {
            Workers.Clear();
        }
        public void Work()
        {
            foreach (var item in Workers)
            {
                AlreadyBuild += item.PowerPerWork;
            }
        }
        public Roof(int buildTime)
        {
            BuildTime = buildTime;
            AlreadyBuild = 0;
            Workers = new List<IWorker>();
        }
        public Roof() : this(300) { }
    }
    #endregion
    class Home
    {
        public Team BuildingTeam { get; set; }
        public Basement HomeBasement { get; set; }
        public IPart[,] MainParts { get; set; }
        public Door MainDoor { get; set; }
        public Roof HomeRoof { get; set; }
        public void Print()
        {
            BuildingTeam.Leader.PrintHome();
        }
        public Home(Team team, bool isDefault)
        {
            BuildingTeam = team;
            BuildingTeam.Leader.BuildingHome = this;
            if (isDefault)
            {
                HomeBasement = new Basement();
                MainParts = new IPart[4, 2];
                for (int i = 0; i < MainParts.GetLength(0); i++)
                {
                    MainParts[i, 0] = new Wall();
                    MainParts[i, 1] = new Window();
                }
                MainDoor = new Door();
                HomeRoof = new Roof();
            }
            else
            {
                int tempBT = Int32.Parse(Console.ReadLine());
                HomeBasement = new Basement(tempBT);
                MainParts = new IPart[4, 2];
                for (int i = 0; i < MainParts.GetLength(0); i++)
                {
                    tempBT = Int32.Parse(Console.ReadLine());
                    MainParts[i, 0] = new Wall(tempBT);
                    tempBT = Int32.Parse(Console.ReadLine());
                    MainParts[i, 1] = new Window(tempBT);
                }
                tempBT = Int32.Parse(Console.ReadLine());
                MainDoor = new Door(tempBT);
                tempBT = Int32.Parse(Console.ReadLine());
                HomeRoof = new Roof(tempBT);
            }
        }
        public IPart this[int part]
        {
            get
            {
                if (part == 0)
                {
                    return HomeBasement;
                }
                else if (part > 0 && part <= 8)
                {
                    return MainParts[(part - 1) / 2, (part - 1) % 2];
                }
                else if (part == 9)
                {
                    return MainDoor;
                }
                else if (part == 10)
                {
                    return HomeRoof;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
    class HW5
    {
        static void Main(string[] args)
        {
            int quantity = Int32.Parse(Console.ReadLine());
            Team team = new Team(quantity, null);
            Home home = new Home(team, true);
            while (!home[0].CheckBuild())
            {
                foreach (var item in home.BuildingTeam.Workers)
                {
                    if (item.CheckPart(home[0]))
                    {
                        int tmp = item.PowerPerWork;
                        home[0].Workers.Add(new Worker(tmp, true));
                    }
                }
                home[0].Work();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                if (home[0].CheckBuild())
                {
                    home[0].AlreadyBuild = home[0].BuildTime;
                }
                home.BuildingTeam.Leader.PrintHome();
                home[0].ClearWorkers();
            }
                for (int i = 1; i <= 9; i++)
                {
                    while (!home[i].CheckBuild())
                    {
                        foreach (var item in home.BuildingTeam.Workers)
                        {
                            int tmp = item.PowerPerWork;
                            home[i].Workers.Add(new Worker(tmp, true));
                        }
                        home[i].Work();
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        if (home[i].CheckBuild())
                        {
                            home[i].AlreadyBuild = home[i].BuildTime;
                        }
                        home.BuildingTeam.Leader.PrintHome();
                        home[i].ClearWorkers();
                    }
                }
            while (!home[10].CheckBuild())
            {
                foreach (var item in home.BuildingTeam.Workers)
                {
                    int tmp = item.PowerPerWork;
                    home[10].Workers.Add(new Worker(tmp, true));
                }
                home[10].Work();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                if (home[10].CheckBuild())
                {
                    home[10].AlreadyBuild = home[10].BuildTime;
                }
                home.BuildingTeam.Leader.PrintHome();
                home[10].ClearWorkers();
            }
            Console.Write($"House built!");
        }
    }
}
