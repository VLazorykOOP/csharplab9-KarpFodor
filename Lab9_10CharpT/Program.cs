// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

//Task1
public class ReverseCheck
{
    public bool IsReverse(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        Stack<char> stack = new Stack<char>();

        foreach (char c in s1)
        {
            stack.Push(c);
        }

        foreach (char c in s2)
        {
            if (stack.Count == 0 || c != stack.Pop())
            {
                return false;
            }
        }

        return true;
    }

    public void Run()
    {
        string s1 = "Hello";
        string s2 = "olleH";

        bool result = IsReverse(s1, s2);

        Console.WriteLine($"'{s2}' протилежниий до '{s1}'? {result}");

        string s1_1 = "Hello";
        string s2_1 = "ogHsl";

        bool result1 = IsReverse(s1_1, s2_1);

        Console.WriteLine($"'{s2_1}' протилежниий до '{s1_1}'? {result1}");
    }

    //Task2
    public class PositiveNegativeOrder
    {
        public void ProcessFile(string filePath)
        {
            Queue<int> positiveQueue = new Queue<int>();
            Queue<int> negativeQueue = new Queue<int>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    int number = int.Parse(reader.ReadLine());

                    if (number > 0)
                    {
                        positiveQueue.Enqueue(number);
                    }
                    else if (number < 0)
                    {
                        negativeQueue.Enqueue(number);
                    }
                }
            }

            PrintQueue(positiveQueue);
            PrintQueue(negativeQueue);
        }

        private void PrintQueue(Queue<int> queue)
        {
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        public void Run()
        {
            string filePath = "input.txt";
            ProcessFile(filePath);
        }
    }


    //Task3
    internal class ReverseCheckArray
    {
        public bool IsReverse(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            ArrayList list1 = new ArrayList(s1.ToCharArray());
            list1.Reverse();

            ArrayList list2 = new ArrayList(s2.ToCharArray());
            return Enumerable.SequenceEqual(list1.Cast<char>(), list2.Cast<char>());
        }

        public void Run()
        {
            string str1 = "hello";
            string str2 = "olleh";

            if (IsReverse(str1, str2))
                Console.WriteLine("Другий рядок є зворотнiм до першого.\n");
            else
                Console.WriteLine("Другий рядок не є зворотнiм до першого.\n");
        }
    }

    //Task3.1
    internal class FileSortingArray
    {
        public void SortNumbers(string filePath)
        {
            ArrayList positiveNumbers = new ArrayList();
            ArrayList negativeNumbers = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    int number = int.Parse(reader.ReadLine());

                    if (number >= 0)
                        positiveNumbers.Add(number);
                    else
                        negativeNumbers.Add(number);
                }
            }

            Console.WriteLine("Позитивнi числа:");
            PrintNumbers(positiveNumbers);

            Console.WriteLine("\nНегативнi числа:");
            PrintNumbers(negativeNumbers);
        }

        private void PrintNumbers(ArrayList numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        public void Run()
        {
            string filePath = "Array.txt";
            SortNumbers(filePath);
        }
    }

    //Task4
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

    // Клас музичний диск
    class MusicDisk
    {
        public string Title { get; set; }
        private Hashtable songs = new Hashtable();

        public void AddSong(string title, string artist)
        {
            Song song = new Song(title, artist);
            songs.Add(title, song);
        }

        public void RemoveSong(string title)
        {
            songs.Remove(title);
        }

        public void DisplayContent()
        {
            Console.WriteLine($"Музичний диск: {Title}");
            foreach (DictionaryEntry entry in songs)
            {
                Console.WriteLine(entry.Value);
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Пiснi виконавця {artist} на диску {Title}:");
            foreach (DictionaryEntry entry in songs)
            {
                Song song = (Song)entry.Value;
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(song);
                }
            }
        }
    }

    // Клас каталог музичних дискiв
    class MusicCatalog
    {
        private Hashtable disks = new Hashtable();

        public void AddDisk(string title)
        {
            disks.Add(title, new MusicDisk { Title = title });
        }

        public void RemoveDisk(string title)
        {
            disks.Remove(title);
        }

        public void AddSongToDisk(string diskTitle, string songTitle, string artist)
        {
            MusicDisk disk = (MusicDisk)disks[diskTitle];
            if (disk != null)
            {
                disk.AddSong(songTitle, artist);
            }
            else
            {
                Console.WriteLine($"Музичний диск з назвою '{diskTitle}' не знайдений.");
            }
        }

        public void RemoveSongFromDisk(string diskTitle, string songTitle)
        {
            MusicDisk disk = (MusicDisk)disks[diskTitle];
            if (disk != null)
            {
                disk.RemoveSong(songTitle);
            }
            else
            {
                Console.WriteLine($"Музичний диск з назвою '{diskTitle}' не знайдений.");
            }
        }

        public void DisplayCatalogContent()
        {
            Console.WriteLine("Каталог музичних дискiв:");
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = (MusicDisk)entry.Value;
                disk.DisplayContent();
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Пошук усiх записiв виконавця {artist} по всьому каталогу:");
            foreach (DictionaryEntry entry in disks)
            {
                MusicDisk disk = (MusicDisk)entry.Value;
                disk.SearchByArtist(artist);
            }
        }
    }

    class Lab9T1
        {
            public void Run()
            {
                Console.WriteLine("===   Task1   ===\n");

                ReverseCheck reverseCheck = new ReverseCheck();
                reverseCheck.Run();
            }

            class Lab9T2
            {
                public void Run()
                {
                    Console.WriteLine("\n\n===   Task2   ===\n");

                    PositiveNegativeOrder pnOrder = new PositiveNegativeOrder();
                    pnOrder.Run();
                }

                class Lab9T3
                {
                    public void Run()
                    {
                        Console.WriteLine("\n\n===   Task3   ===\n");

                        ReverseCheckArray reverseCheckA = new ReverseCheckArray();
                        reverseCheckA.Run();
                        FileSortingArray fileArray = new FileSortingArray();
                        fileArray.Run();

                    }
                }

                class Lab9T4
                {
                    public void Run()
                    {
                        Console.WriteLine("\n\n===   Task4   ===\n");

                    MusicCatalog catalog = new MusicCatalog();

                    // Додавання дискiв
                    catalog.AddDisk("Rock Hits");
                    catalog.AddDisk("Pop Favorites");

                    // Додавання пiсень на диски
                    catalog.AddSongToDisk("Rock Hits", "Bohemian Rhapsody", "Queen");
                    catalog.AddSongToDisk("Rock Hits", "Smells Like Teen Spirit", "Nirvana");
                    catalog.AddSongToDisk("Pop Favorites", "Shape of You", "Ed Sheeran");
                    catalog.AddSongToDisk("Pop Favorites", "Despacito", "Luis Fonsi");

                    // Видалення пiснi з диску
                    catalog.RemoveSongFromDisk("Pop Favorites", "Shape of You");

                    // Вiдображення вмiсту каталогу
                    catalog.DisplayCatalogContent();

                    // Пошук пiсень за виконавцем
                    catalog.SearchByArtist("Queen");

                }


                    class Program
                    {
                        static void Main()
                        {
                            Lab9T1 lab8task1 = new Lab9T1();
                            Lab9T2 lab8task2 = new Lab9T2();
                            Lab9T3 lab8task3 = new Lab9T3();
                            Lab9T4 lab8task4 = new Lab9T4();

                            lab8task1.Run();
                            lab8task2.Run();
                            lab8task3.Run();
                            lab8task4.Run();

                        }
                    }
                }
            }
        }
    }

