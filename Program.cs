using System;
using System.IO;

namespace lab2_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"DataBase");
            string defaultpath = @"DataBase\StudentsBD.txt";
            try
            {
                string[] ReadenLines = File.ReadAllLines(defaultpath);
            }
            catch
            {
                File.WriteAllText(defaultpath,
                    "1 Иванов Сергей Михайлович 01.07.03 ИТАСУ БПИ20-9 2 3,2\n" +
                    "2 Алексей Истомин Иванович 02.08.01 ИТАСУ БПИ20-8 2 4,3\n" +
                    "3 Сергеев Наруто Евгеньевич 02.02.01 ИТАСУ БПИ20-5 3 4,4\n" +
                    "4 Сергеев Наруто Евгеньевич 02.02.01 ИТАСУ БПИ20-5 3 4,4\n" +
                    "5 Иванов Михаил Сергеевич 01.04.03 ИТАСУ БПИ20-9 2 4,2");



                Console.Title = "ПРЕДУПРЕЖДЕНИЕ";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(new string(' ', (Console.WindowWidth - 9) / 2));
                Console.WriteLine("ВНИМАНИЕ\n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Формат ввода данных в файлах:\n\n{Номер} [Фамилия] [Имя] [Отчество] {**.**.**} [Институт] [Группа] [Курс] {*,*}\n1 Иванов Сергей Михайлович 01.07.03 ИТАСУ БПИ20-9 2 3,2\n");
                Console.WriteLine("При вводе даты рождения студента, ввод начнется с ДНЯ рождения, продолжится МЕСЯЦОМ и закончится ГОДОМ\nПример: 4->Enter, 2->Enter,2001->Enter");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nЧтобы вернуться в главное меню, если вы вошли в ненужную вкладку, просто нажмите Enter, а потом нажмите ESC");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n--------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
                Console.ResetColor();
                Console.ReadKey();
            }
            Functions Func = new Functions();
            Func.MainMenu();
        }
    }
}