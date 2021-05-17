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
        }
        public Folder(string title) : base(title, 0)
        {
            Files = new List<File>();
            size = 0;
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
    class Sector : Folder
    {
        public int MaxSize { get; set; }
        public Sector(string title, int maxSize) : base(title)
        {
            Files = new List<File>();
            size = 0;
            MaxSize = maxSize;
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
        }
        public FileManager()
        {
            Files = new List<File>();
            size = 0;
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
            StorageManager = new FileManager();
            Name = name;
            Model = model;
            StorageManager.MaxSize = capacity > 0 ? capacity : -capacity;
            Speed = speed > 0 ? speed : -speed;
        }
    }
    class DVD : Storage
    {
        public DVD(string name, string model, bool capacity, int speed)
        {
            StorageManager = new FileManager();
            Name = name;
            Model = model;
            Speed = speed > 0 ? speed : -speed;
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
    class HDD : Storage
    {
        public HDD(string name, string model, int sectors, int speed)
        {
            StorageManager = new FileManager();
            Name = name;
            Model = model;
            Speed = speed > 0 ? speed : -speed;
            int maxSize = 0;
            for (int i = 0; i < sectors; i++)
            {
                Console.Clear();
                Console.Write("Sector title: ");
                string title = Console.ReadLine();
                Console.Write("Sector size: ");
                int sectorSize = Int32.Parse(Console.ReadLine());
                sectorSize = sectorSize > 0 ? sectorSize : -sectorSize;
                maxSize += sectorSize;
                StorageManager.Files.Add(new Sector(title, maxSize));
            }
            Console.Clear();
            StorageManager.MaxSize = maxSize;
        }
    }
    class HW4
    {
        static void Main(string[] args)
        {
            try
            {
                int numberOfStorages = Int32.Parse(Console.ReadLine());
                if (numberOfStorages <= 0)
                {
                    throw new Exception("Number of storages cannot be zero or negative");
                }
                else if(numberOfStorages > 10)
                {
                    throw new Exception("Number of storages cannot exceed 10");
                }
                Storage[] storages = new Storage[numberOfStorages];
                for (int i = 0; i < numberOfStorages; i++)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Flash, 2 - DVD, else - HDD");
                    int type = Int32.Parse(Console.ReadLine());
                    if (type == 1)
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Capacity: ");
                        int capacity = Int32.Parse(Console.ReadLine());
                        Console.Write("Speed: ");
                        int speed = Int32.Parse(Console.ReadLine());
                        storages[i] = new Flash(name, model, capacity, speed);
                    }
                    else if (type == 2)
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("1 - for one-sided DVD, 2 - for two-sided DVD");
                        int intCapacity = Int32.Parse(Console.ReadLine());
                        Console.Write("Speed: ");
                        int speed = Int32.Parse(Console.ReadLine());
                        bool capacity = intCapacity != 1;
                        storages[i] = new DVD(name, model, capacity, speed);
                    }
                    else
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Model: ");
                        string model = Console.ReadLine();
                        Console.Write("Number of sectors: ");
                        int numberOfSectors = Int32.Parse(Console.ReadLine());
                        Console.Write("Speed: ");
                        int speed = Int32.Parse(Console.ReadLine());
                        storages[i] = new HDD(name, model, numberOfSectors, speed);
                    }
                }
                int gen = 0;
                FileManager fileManager = null;
                Folder folder = null;
                while (true)
                {
                    Console.Clear();
                    int ii = 0, memory = 0, allMemory = 0;
                    if (gen == 0)
                    {
                        foreach (var item in storages)
                        {
                            Console.Write($"[{ii++}] ");
                            item.Print();
                            memory = item.StorageManager.Size;
                            allMemory += item.StorageManager.MaxSize;
                        }
                        Console.WriteLine($"{memory} / {allMemory}");
                        ConsoleKeyInfo readKey = Console.ReadKey();
                        Console.WriteLine();
                        if (readKey.KeyChar >= '0' && readKey.KeyChar <= '9')
                        {
                            try
                            {
                                fileManager = storages[readKey.KeyChar - '0'].StorageManager;
                                gen++;
                            }
                            catch (Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                        else if (readKey.Key == ConsoleKey.Escape || readKey.Key == ConsoleKey.Backspace)
                        {
                            break;
                        }
                        else if (readKey.KeyChar == 'q') //D2C/C2D CopyTime
                        {
                            try {
                                int storageInt = Int32.Parse(Console.ReadLine());
                                Storage storage = storages[storageInt];
                                int memorySize = Int32.Parse(Console.ReadLine());
                                if (memorySize > storage.StorageManager.MaxSize)
                                {
                                    throw new Exception("Too big file");
                                }
                                Console.WriteLine($"Copy time - {memorySize / storage.Speed}");
                            }
                            catch(Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                        else if (readKey.KeyChar == 'w') //D2D CopyTime
                        {
                            try
                            {
                                int storageInt1 = Int32.Parse(Console.ReadLine());
                                Storage storage1 = storages[storageInt1];
                                int storageInt2 = Int32.Parse(Console.ReadLine());
                                Storage storage2 = storages[storageInt2];
                                int memorySize = Int32.Parse(Console.ReadLine());
                                if (memorySize > storage1.StorageManager.MaxSize || memorySize > storage2.StorageManager.MaxSize)
                                {
                                    throw new Exception("Too big file");
                                }
                                Console.WriteLine($"Copy time - {memorySize / Math.Min(storage1.Speed, storage2.Speed)}");
                            }
                            catch (Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                        else if (readKey.KeyChar == 'e')
                        {
                            for (int i = 0; i < storages.Length - 1; i++)
                            {
                                for (int l = 0; l < storages.Length - 1 - i; l++)
                                {
                                    if(storages[l].StorageManager.MaxSize> storages[l + 1].StorageManager.MaxSize)
                                    {
                                        Storage tmpStorage = storages[l];
                                        storages[l] = storages[l + 1];
                                        storages[l + 1] = tmpStorage;
                                    }
                                }
                            }
                            int size = Int32.Parse(Console.ReadLine());
                            if (size < 0) { size = -size; }
                            List<Storage> tmpStorages = new List<Storage>();
                            while (true)
                            {
                                bool isAdd = false;
                                foreach (var item in storages)
                                {
                                    if (size <= item.StorageManager.MaxSize)
                                    {
                                        tmpStorages.Add(item);
                                        size -= item.StorageManager.MaxSize;
                                        isAdd = true;
                                        break;
                                    }
                                }
                                if (!isAdd)
                                {
                                    tmpStorages.Add(storages[storages.Length - 1]);
                                    size -= storages[storages.Length - 1].StorageManager.MaxSize;
                                    isAdd = true;
                                }
                                if (size <= 0)
                                {
                                    break;
                                }
                            }
                            foreach (var item in tmpStorages)
                            {
                                item.Print();
                            }
                            Console.ReadKey();
                        }
                        else if (readKey.KeyChar == 'r') //D2C/C2D CopyTime
                        {
                            try
                            {
                                int storageInt = Int32.Parse(Console.ReadLine());
                                Storage storage = storages[storageInt];
                                int fileSize = Int32.Parse(Console.ReadLine());
                                if (fileSize > storage.StorageManager.MaxSize)
                                {
                                    throw new Exception("Too big file");
                                }
                                string tmpStr = Console.ReadLine();
                                storage.StorageManager.AddFile(tmpStr, fileSize);
                            }
                            catch (Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (gen == 1)
                    {
                        foreach (var item in fileManager.Files)
                        {
                            Console.Write($"[{ii++}] ");
                            Console.WriteLine($"{item.Title} - {item.Size}");
                        }
                        ConsoleKeyInfo readKey = Console.ReadKey();
                        if(readKey.Key == ConsoleKey.Escape || readKey.Key == ConsoleKey.Backspace)
                        {
                            gen = 0;
                        }
                        else if (readKey.KeyChar >= '0' && readKey.KeyChar <= '9')
                        {
                            try
                            {
                                folder = (Folder)fileManager.Files[readKey.KeyChar - '0'];
                                gen++;
                            }
                            catch (Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in folder.Files)
                        {
                            Console.Write($"[{ii++}] ");
                            Console.WriteLine($"{item.Title} - {item.Size}");
                        }
                        ConsoleKeyInfo readKey = Console.ReadKey();
                        if (readKey.Key == ConsoleKey.Escape)
                        {
                            gen = 0;
                        }
                        else if (readKey.Key == ConsoleKey.Backspace)
                        {
                            gen = 1;
                        }
                        else if (readKey.KeyChar >= '0' && readKey.KeyChar <= '9')
                        {
                            try
                            {
                                folder = (Folder)folder.Files[readKey.KeyChar - '0'];
                                gen++;
                            }
                            catch (Exception exception)
                            {
                                Console.Clear();
                                Console.WriteLine(exception);
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception);
                Console.ReadKey();
            }
        }
    }
}
