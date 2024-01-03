using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7._1
{
    class Repository
    {
        public Worker[] GetAllWorkers(/**/)
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров

            int numberOfWorkers = File.ReadAllLines(path).Length;
            Worker[] workers = new Worker[numberOfWorkers];
            using (StreamReader sr = new StreamReader(path))
            {
                string s = string.Empty;
                int i = 0;
                while (s != null)
                {
                    s = sr.ReadLine();
                    if (s == null) break;
                    workers[i] = new Worker(s.Split('#'));
                    i++;
                } 
            }
            return workers;
        }

        public void GetAllWorkersToScreen(Worker[] workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                Console.Write(workers[i].Id + " " + workers[i].Date + " " + workers[i].FIO
                    + " " + workers[i].Age + " " + workers[i].Height
                    + " " + workers[i].DateOfBirth + " " + workers[i].PlaceOfBirth);
                Console.WriteLine();
            }
        }

        public void GetWorkerToScreen(Worker worker)
        {
            Console.Write(worker.Id + " " + worker.Date + " " + worker.FIO
                    + " " + worker.Age + " " + worker.Height
                    + " " + worker.DateOfBirth + " " + worker.PlaceOfBirth);
            Console.WriteLine();
        }

        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            Worker w = new Worker();
            using (StreamReader sr = new StreamReader(path))
            {
                string s = string.Empty;
                do
                {
                    s = sr.ReadLine();
                } while (id != Convert.ToInt32(s.Split('#')[0]));
                w = new Worker(s.Split('#'));
            }
            return w;
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
            List<string> str1 = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s = string.Empty;
                do
                {
                    s = sr.ReadLine();
                    if (s == null) break;
                    if (id != Int32.Parse(s.Split('#')[0]))
                    {
                        str1.Add(s);
                    }
                } while (s != null);
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string s in str1)
                {
                    sw.WriteLine(s);
                }
            }
        }

        public void AddWorker()
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            int id = File.ReadAllLines(path).Length + 1;
            string[] str = new string[7];
            str[0] = Convert.ToString(id);
            str[1] = DateTime.Now.ToString();
            Console.WriteLine("Full Name");
            str[2] = Console.ReadLine();
            Console.WriteLine("y.o.");
            str[3] = Console.ReadLine();
            Console.WriteLine("Height");
            str[4] = Console.ReadLine();
            Console.WriteLine("Birth Date");
            str[5] = Console.ReadLine();
            Console.WriteLine("Birth Place");
            str[6] = Console.ReadLine();
            for (int j = 0; j < 6; j++)
                str[j] += "#";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine();
                foreach (string s in str)
                {
                    sw.Write(s);
                }
            }
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            int id = File.ReadAllLines(path).Length + 1;
            string[] str = new string[7];
            str[0] = Convert.ToString(worker.Id);
            str[1] = worker.Date.ToString();
            str[2] = worker.FIO;
            str[3] = Convert.ToString(worker.Age);
            str[4] = Convert.ToString(worker.Height);
            str[5] = worker.DateOfBirth.ToString();
            str[6] = worker.PlaceOfBirth;
            for (int j = 0; j < 6; j++)
                str[j] += "#";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine();
                foreach (string s in str)
                {
                    sw.Write(s);
                }
            }
        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров

            int numberOfWorkers = File.ReadAllLines(path).Length;
            List<Worker> workers = new List<Worker>();
            using (StreamReader sr = new StreamReader(path))
            {
                string s = string.Empty;
                do
                {
                    s = sr.ReadLine();
                    if (DateTime.Parse(s.Split('#')[1]) >= dateFrom && DateTime.Parse(s.Split('#')[1]) <= dateTo)
                    {
                        workers.Add(new Worker(s.Split('#')));
                    }
                } while (s != null);
            }
            return workers.ToArray();
        }

        public void SortByID()
        {
            Worker[] workers = this.GetAllWorkers();
            for(int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers.Length - 1 - i; j++)
                {
                    if (workers[j].Id > workers[j+1].Id)
                    {
                        Worker w = new Worker();
                        w = workers[j];
                        workers[j] = workers[j + 1];
                        workers[j + 1] = w;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            { }
            for (int i = 0; i < workers.Length; i++)
            {
                this.AddWorker(workers[i]);
            }
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Skip(1).ToArray());
        }

        public void SortByDate()
        {
            Worker[] workers = this.GetAllWorkers();
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers.Length - 1 - i; j++)
                {
                    if (workers[j].Date > workers[j + 1].Date)
                    {
                        Worker w = new Worker();
                        w = workers[j];
                        workers[j] = workers[j + 1];
                        workers[j + 1] = w;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            { }
            for (int i = 0; i < workers.Length; i++)
            {
                this.AddWorker(workers[i]);
            }
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Skip(1).ToArray());
        }

        public void SortByDateOfBirth()
        {
            Worker[] workers = this.GetAllWorkers();
            for (int i = 0; i < workers.Length; i++)
            {
                for (int j = 0; j < workers.Length - 1 - i; j++)
                {
                    if (workers[j].DateOfBirth > workers[j + 1].DateOfBirth)
                    {
                        Worker w = new Worker();
                        w = workers[j];
                        workers[j] = workers[j + 1];
                        workers[j + 1] = w;
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            { }
            for (int i = 0; i < workers.Length; i++)
            {
                this.AddWorker(workers[i]);
            }
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Skip(1).ToArray());
        }

        private string path = @"d:\Skill.txt";
    }
}
