using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class File
    {
        public string Title { get; set; }
        protected int size;
        public virtual int Size
        {
            get { return size; }
            set { size = value; }
        }
        public File(string title, int size)
        {
            Title = title;
            Size = size;
        }
    }
    class Folder : File
    {
        public List<File> Files { get; set; }
        public override int Size
        {
            get
            {
                size = 0;
                foreach (var item in Files)
                {
                    size += item.Size;
                }
                return size;
            }
            set
            {
                size = 0;
                foreach (var item in Files)
                {
                    size += item.Size;
                }
            }
        }
        public Folder(string title) : base(title, 0)
        {
            Files = new List<File>();
        }
        public void AddFile(string title, int size)
        {
            Files.Add(new File(title, size));
        }
        public void AddFile(string title, int size, int currentSize, int maxSize)
        {
            try
            {
                if (size + currentSize > maxSize)
                {
                    throw new Exception("File too big");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Files.Add(new File(title, size));
        }
        public void AddFile(string title, int size, int maxSize)
        {
            try
            {
                if (size > maxSize)
                {
                    throw new Exception("File too big");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Files.Add(new File(title, size));
        }
    }
    class FileManager
    {
        public List<File> Files { get; set; }
        public int MaxSize { get; set; }
        protected int size;
        public int Size
        {
            get
            {
                size = 0;
                foreach (var item in Files)
                {
                    size += item.Size;
                }
                return size;
            }
            set
            {
                size = 0;
                foreach (var item in Files)
                {
                    size += item.Size;
                }
            }
        }
        public FileManager()
        {
            Files = new List<File>();
            Size = 0;
        }
        public void AddFile(string title, int size)
        {
            try
            {
                if (size > MaxSize - Size)
                {
                    throw new Exception("File too big");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Files.Add(new File(title, size));
        }
        public void AddFolder(string title)
        {
            Files.Add(new Folder(title));
        }
    }
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public FileManager StorageManager { get; set; }
        public int GetCapacity()
        {
            return StorageManager.MaxSize;
        }
        public int GetSize()
        {
            return StorageManager.Size;
        }
        public void CopyFiles(Storage storage)
        {
            try
            {
                if ((this.StorageManager.MaxSize - this.StorageManager.Size) < storage.GetSize())
                {
                    throw new Exception("Too big files to copy");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            foreach (var item in storage.StorageManager.Files)
            {
                StorageManager.Files.Add(item);
            }
        }
        public void OverrideFiles(Storage storage)
        {
            try
            {
                if ((this.StorageManager.MaxSize - this.StorageManager.Size) < storage.GetSize())
                {
                    throw new Exception("Too big files to copy");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            StorageManager.Files.Clear();
            foreach (var item in storage.StorageManager.Files)
            {
                StorageManager.Files.Add(item);
            }
        }
        public void Print()
        {
            Console.WriteLine($"{Name} - {Model}; {GetSize()} / {GetCapacity()} MB; Speed - {Speed} MB/second");
        }
    }
    class Flash : Storage
    {
        public Flash(string name, string model, int capacity, int speed)
        {
            Name = name;
            Model = model;
            StorageManager.MaxSize = capacity;
            Speed = speed;
        }
    }
    class DVD : Storage
    {
        public DVD(string name, string model, bool capacity, int speed)
        {
            Name = name;
            Model = model;
            Speed = speed;
            if (capacity)
            {
                StorageManager.MaxSize = 9216;
            }
            else
            {
                StorageManager.MaxSize = 4608;
            }
        }
    }
    class HW4
    {
        static void Main(string[] args)
        {
            
        }
    }
}
