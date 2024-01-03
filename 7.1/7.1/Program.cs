using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\Skill.txt";
            Repository rp = new Repository();
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                { }
                Console.WriteLine("Добавьте первую запись в файл");
                rp.AddWorker();
                var lines = File.ReadAllLines(path);
                File.WriteAllLines(path, lines.Skip(1).ToArray());
            }
            else
            {
                Console.WriteLine("Нажмите 1 чтобы вывести всех работников на экран");
                Console.WriteLine("Нажмите 2 чтобы найти работника по ID");
                Console.WriteLine("Нажмите 3 чтобы удалить работника по ID");
                Console.WriteLine("Нажмите 4 чтобы добавить нового работника");
                Console.WriteLine("Нажмите 5 чтобы отсортировать по ID");
                Console.WriteLine("Нажмите 6 чтобы отсортировать по дате");
                Console.WriteLine("Нажмите 7 чтобы отсортировать по дате рождения");
                char c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (c == '1')
                {
                    rp.GetAllWorkersToScreen(rp.GetAllWorkers());
                }
                else if (c == '2')
                {
                    Console.WriteLine("Введите ID");
                    rp.GetWorkerToScreen(rp.GetWorkerById(Int32.Parse(Console.ReadLine())));
                }
                else if (c == '3')
                {
                    Console.WriteLine("Введите ID");
                    rp.DeleteWorker(Int32.Parse(Console.ReadLine()));
                }
                else if (c == '4')
                {
                    rp.AddWorker();
                }
                else if (c == '5')
                {
                    rp.SortByID();
                }
                else if (c == '6')
                {
                    rp.SortByDate();
                }
                else if (c == '7')
                {
                    rp.SortByDateOfBirth();
                }
                Console.ReadKey();
            }
        }
    }
}
