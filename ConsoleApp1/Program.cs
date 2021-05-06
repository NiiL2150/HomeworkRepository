using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.SampleClasses1;
using ConsoleApp1.SampleClasses1.Interfaces;

namespace ConsoleApp1
{
    class BankCard
    {
        public int CardSeria { get; set; }
        public BankCard(int _CardSeria)
        {
            CardSeria = _CardSeria;
        }
        public override string ToString()
        {
            return $"{CardSeria}";
        }
    }
    class Student : IComparable, ICloneable
    {
        public string FullName { get; set; }
        public string CardID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double AvgScore { get; set; }
        public BankCard bankCard { get; set; }
        public Student(string fullName, string cardID, DateTime dateOfBirth, double avgScore, BankCard _bankCard)
        {
            this.FullName = fullName;
            this.CardID = cardID;
            this.DateOfBirth = dateOfBirth;
            this.AvgScore = avgScore;
            this.bankCard = _bankCard;
        }
        public override string ToString()
        {
            return $"{FullName} {CardID} {DateOfBirth} {AvgScore} {bankCard}";
        }
        public int CompareTo(object obj)
        {
            if(obj is Student)
            {
                return AvgScore.CompareTo((obj as Student).AvgScore);
            }
            throw new NotImplementedException();
        }

        public object Clone()
        {
            Student tmp = (Student)this.MemberwiseClone();
            tmp.bankCard = new BankCard(this.bankCard.CardSeria);
            return tmp;
        }
    }

    class NameCompare : IComparer
    {
        public bool isReverse { get; set; }
        public NameCompare(bool _isReverse)
        {
            isReverse = _isReverse;
        }
        public int Compare (object x, object y)
        {
            if (isReverse)
            {
                return String.Compare((y as Student).FullName, (x as Student).FullName);
            }
            else
            {
                return String.Compare((x as Student).FullName, (y as Student).FullName);
            }
        }
    }

    class Group : IEnumerable
    {
        Student[] students;//Array<Student>
        public string Name { get; set; }
        public Group()
        {
            Name = "CS1";
            students = new Student[3] {
                new Student("Dmitriy Makarshin",
                "1F568Z01",
                 DateTime.Now,
                199.12,
                new BankCard(123)),
              new Student("Javid Mecidzadeh",
                "1F568Z01",
                 DateTime.Now,
                10.12,
                new BankCard(234)),
                  new Student("Kanan Gurbanov",
                "1F568Z01",
                 DateTime.Now,
                9.12,
                new BankCard(345)),
            };
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }
        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*IManaging manager = new Manager("Nail", "Cool guy", 10000);
            manager.Workers.Add(new Worker("Nail2", "Another cool guy", 1000));
            manager.Workers.Add(new Worker("Nail3", "Yet another cool guy", 100));
            manager.Workers.Add(new Worker("Nail4", "Yet yet another cool guy", 10));
            foreach (IWorking item in manager.Workers)
            {
                Console.WriteLine(item);
            }*/

            /*Group group = new Group();
            group.Sort();
            foreach(var item in group)
            {
                Console.WriteLine(item);
            }
            group.Sort(new NameCompare(false));
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }
            group.Sort(new NameCompare(true));
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }*/


        }
    }
}
