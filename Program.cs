using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lab2_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"DataBase");
            string defaultpath = @"DataBase\StudentsBD.txt";
            try { 
                string[] ReadenLines = File.ReadAllLines(defaultpath);
            }
            catch { 
                File.WriteAllText(defaultpath, "1 Иванов Сергей Михайлович 01.07.03 ИТАСУ БПИ20-9 2 3,2\n" +
                    "2 Алексей Истомин Иванович 02.08.01 ИТАСУ БПИ20-8 2 4,3\n" +
                    "3 Сергеев Наруто Евгеньевич 02.02.21 ИТАСУ БПИ20-5 3 4,4");
            }
            Functions Func = new Functions();
            Func.MainMenu();
        }
    }
}