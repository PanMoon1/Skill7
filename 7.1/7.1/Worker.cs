using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1
{
    struct Worker
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public Worker(string[] str)
        {
            this.Id = Int32.Parse(str[0]);
            this.Date = DateTime.Parse(str[1]);
            this.FIO = str[2];
            this.Age = Int32.Parse(str[3]);
            this.Height = Int32.Parse(str[4]);
            this.DateOfBirth = DateTime.Parse(str[5]);
            this.PlaceOfBirth = str[6];
        }
    }
}
