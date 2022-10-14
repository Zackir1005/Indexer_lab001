using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Indexers_lab
{
    interface ICounter
    {
        int count { get; }
        void BriefPrint();
    }
    interface IWhenCreated
    {
        DateTime Created { get; }
    }
    interface IWriteToDisk
    {
        string filename { get; }
        bool SaveToDisk();
        bool ReadFromDisk();
    }
    class Program
    {
        public static string[] _weekDays = new string[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
        public static void MyInput(EmployerTime EmpTime)
        {
            bool TF = true;
            do
            {
                try
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine($"Введите сколько часов проработал в {_weekDays[i]}");
                        EmpTime[i] = int.Parse(Console.ReadLine());
                        if (EmpTime[i] > 8)
                        {
                            EmpTime[i] = 8;
                        }
                        else
                        {
                            if (EmpTime[i] < 0)
                            {
                                EmpTime[i] = 0;
                            }
                        }
                    }
                    TF = false;
                }
                catch
                {
                    Console.WriteLine("ОШИБКА!ПОПРОБУЙТЕ ЕЩЁ РАЗ!");
                }
            } while (TF);

            EmpTime.Print();
            Console.WriteLine($"\nОтработано {EmpTime.count} часов");
            Console.WriteLine(EmpTime.Created);
        }
        static void Main(string[] args)
        {
            var BobTime = new EmployerTime();
            MyInput(BobTime);
            var JohnTime = new EmployerTime();
            MyInput(JohnTime);
            Console.ReadKey();
        }
    }
}