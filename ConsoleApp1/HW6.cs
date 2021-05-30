using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CarEventHandler
    {
        public CarEventHandler(string message, string title)
        {
            Message = message;
            Title = title;
        }
        public string Message { get; set; }
        public string Title { get; set; }
    }

    public abstract class Car
    {
        public delegate void CarDelegate(object sender, CarEventHandler e);
        static public event CarDelegate Notify;
        public void NotifyEvent(object sender, CarEventHandler e)
        {
            Notify?.Invoke(sender, e);
        }
        public void PrintInfo()
        {
            Notify?.Invoke(this, new CarEventHandler($"Title: {Title}\nMin speed: {MinSpeed};\nMax speed: {MaxSpeed}\n", $"{Title} car info"));
        }

        protected readonly Random rnd;
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public int Distance { get; set; }
        public string Title { get; set; }
        public int Speed
        {
            get
            {
                return (rnd.Next(MinSpeed, MaxSpeed));
            }
        }
        abstract protected int Accelerate();
        public void Drive()
        {
            Distance += Accelerate();
        }

        public Car(string title, int minSpeed, int maxSpeed)
        {
            rnd = new Random();
            Title = title;
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            Distance = 0;
        }
        public Car(string title, int maxSpeed) : this(title, 1, maxSpeed) { }
        public Car(string title = "Unnamed") : this(title, 10) { }
    }

    public class SportCar : Car
    {
        protected override int Accelerate()
        {
            return Speed * rnd.Next(1, 3);
        }
        public SportCar(string title, int minSpeed, int maxSpeed) : base(title, minSpeed, maxSpeed) { }
        public SportCar(string title, int maxSpeed) : base(title, maxSpeed) { }
        public SportCar(string title = "UnnamedSC") : base(title) { }
    }

    public class PassengerCar : Car
    {
        protected override int Accelerate()
        {
            return Speed + rnd.Next(10);
        }
        public PassengerCar(string title, int minSpeed, int maxSpeed) : base(title, minSpeed, maxSpeed) { }
        public PassengerCar(string title, int maxSpeed) : base(title, maxSpeed) { }
        public PassengerCar(string title = "UnnamedPC") : base(title) { }
    }

    public class Truck : Car
    {
        protected override int Accelerate()
        {
            return Speed;
        }
        public Truck(string title, int minSpeed, int maxSpeed) : base(title, minSpeed, maxSpeed) { }
        public Truck(string title, int maxSpeed) : base(title, maxSpeed) { }
        public Truck(string title = "UnnamedT") : base(title) { }
    }
    public class Bus : Car
    {
        protected override int Accelerate()
        {
            return Speed + rnd.Next(5);
        }
        public Bus(string title, int minSpeed, int maxSpeed) : base(title, minSpeed, maxSpeed) { }
        public Bus(string title, int maxSpeed) : base(title, maxSpeed) { }
        public Bus(string title = "UnnamedB") : base(title) { }
    }

    public class Race : IEnumerable
    {
        public Car[] Cars { get; set; }
        readonly int trackDistance;
        
        public bool CheckFinish()
        {
            foreach (Car item in Cars)
            {
                if (item.Distance >= trackDistance)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Car> CheckWin()
        {
            int maxDistance = 0;
            List<Car> cars = new List<Car>();
            foreach (Car item in Cars)
            {
                if (item.Distance > maxDistance)
                {
                    maxDistance = item.Distance;
                    cars.Clear();
                    cars.Add(item);
                }
                else if (item.Distance == maxDistance)
                {
                    cars.Add(item);
                }
            }
            return cars;
        }
        public void Drive()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(500);
                foreach (Car item in Cars)
                {
                    item.Drive();
                }
                if (CheckFinish())
                {
                    Console.Clear();
                    foreach (Car item in Cars)
                    {
                        item.NotifyEvent(item, new CarEventHandler($"{item.Title}: {item.Distance}/{trackDistance}", $"{Cars.Length} cars in the race"));
                    }
                    List<Car> cars = CheckWin();
                    Console.WriteLine($"{cars.Count} car(s) won:");
                    foreach (Car item in cars)
                    {
                        item.NotifyEvent(item, new CarEventHandler($"{item.Title} won with the distance of {item.Distance}/{trackDistance}", $"{cars.Count} car(s) won"));
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    foreach (Car item in Cars)
                    {
                        item.NotifyEvent(item, new CarEventHandler($"{item.Title}: {item.Distance}/{trackDistance}", $"{Cars.Length} cars in the race"));
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Cars.GetEnumerator();
        }

        public Race(Car[] cars, int trackDistance = 100)
        {
            this.Cars = cars;
            this.trackDistance = trackDistance;
        }
    }

    class HW6
    {
        static void Main(string[] args)
        {
            Car.Notify += ConsoleOutputForCar;
            Car.Notify += WindowOutputForCar;
            Car[] cars = new Car[4]
            {
                new SportCar("Dodge Viper", 3, 8),
                new PassengerCar("Chevrolet Malibu", 2, 7),
                new Bus("ISUZU", 4, 9),
                new Truck("Kamaz", 5, 10)
            };
            foreach (var item in cars)
            {
                item.PrintInfo();
            }
            System.Threading.Thread.Sleep(2500);
            Race race = new Race(cars);
            race.Drive();
        }

        public static void ConsoleOutputForCar(object sender, CarEventHandler e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
        }

        public static void WindowOutputForCar(object sender, CarEventHandler e)
        {
            MessageBox.Show(e.Message, e.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
