using System;
using System.Collections;

namespace Indexers_lab
{
    enum DayOfWeek
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
    class EmployerTime : ICounter, IWhenCreated//, IWriteToDisk // Sdelay sokhraneniye v fayl
    {
        private int[] WorkTime;
        private int summOfHours;
        private DateTime CreatedTime;
        private string name;
        public string Name { get; }
        public DateTime Created
        {
            get
            {
                Console.WriteLine($"Объект {this.ToString()} был создан {CreatedTime.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                return CreatedTime;
            }
        }
        public int count
        {
            get
            {
                foreach (var item in WorkTime)
                {
                    summOfHours += item;
                }
                return summOfHours;
            }
        }
        public void BriefPrint()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"{item} - {WorkTime[(int)item]}");
            }
        }
        public EmployerTime(string _name)
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = _name;
        }
        public EmployerTime()
        {
            WorkTime = new int[7];
            summOfHours = 0;
            CreatedTime = DateTime.Now;
            this.name = "John Dow #" + CreatedTime.ToString();
        }
        public int this[int index]
        {
            set { WorkTime[index] = value; }
            get { return WorkTime[index]; }
        }
        public void Print()
        {
            foreach (var item in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine($"В день {item} отработано {WorkTime[(int)item]}");
            }
        }
    }
}