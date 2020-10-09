using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using System.Threading;

namespace lab2_DB
{
    class Functions
    {
        public bool Editing = false;
        List<Student> TotalList = new List<Student>();
        public void GotExeption(int WhatIsTheCase, string WhatHappened, string Solution)
        {
            switch (WhatIsTheCase)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(WhatHappened);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(Solution);
                    Console.ResetColor();
                    Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                    MainMenu();
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(WhatHappened);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(Solution);
                    Console.ResetColor();
                    Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }
        public void MainMenu()
        {
            Console.Title = "Лабораторная работа 2 | Работа с базой данных | Удалых Максим БПИ 20-9";
            int Coice = 0, key;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Главное меню");
                Console.ResetColor();
                Console.WriteLine(((Coice == 0) ? ">> " : " ") + "Вывести базу данных и посмотреть доп. информацию");
                Console.WriteLine(((Coice == 1) ? ">> " : " ") + "Операции с базой данных");

                key = (int)Console.ReadKey().Key;
                if (key == 38) Coice--;
                if (key == 40) Coice++;
                if (key == 13 || key == 27) break;

                if (Coice < 0) Coice = 1;
                if (Coice > 1) Coice = 0;

            } while (key != 27);

            switch (Coice)
            {
                case 0:
                    Console.Clear();
                    OutputMenu();
                    break;

                case 1:
                    Console.Clear();
                    EditorMenu();
                    break;
            }
            Console.ReadKey();
        } //Меню
        #region VisualMenus
        //-----------------EDITORMENU-------------------//
        private void EditorMenu()
        {
            Console.Title = "Редактор";
            int Coice = 0, key;
            do {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Меню редактора");
                Console.ResetColor();
                Console.WriteLine(((Coice == 0) ? ">> " : " ") + "Сортировать Базу данных");
                Console.WriteLine(((Coice == 1) ? ">> " : " ") + "Добавить студента в Базу данных");
                Console.WriteLine(((Coice == 2) ? ">> " : " ") + "Изменить инфо студента в Базе данных");
                Console.WriteLine(((Coice == 3) ? ">> " : " ") + "Удалить студента из Базы данных");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Coice == 4) ? ">> " : " ") + "Назад");
                Console.ResetColor();

                key = (int)Console.ReadKey().Key;
                if (key == 38) Coice--;
                if (key == 40) Coice++;
                if (key == 13 || key == 27) break;

                if (Coice < 0) Coice = 4;
                if (Coice > 4) Coice = 0;

            } while (key != 27);

            switch (Coice)
            {
                case 0:
                    Console.Clear();
                    SortElementsByOrderMenu();
                    break;

                case 1:
                    Console.Clear();
                    AddElement();
                    break;

                case 2:
                    Console.Clear();
                    EditElement();
                    break;

                case 3:
                    Console.Clear();
                    DeleteElement();
                    break;
                case 4:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        private void SortElementsByOrderMenu()
        {
            ReadListFile(false);
            Console.Title = "Сортировка";
            int Coice = 0, key;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Меню сортировки");
                Console.ResetColor();
                Console.WriteLine(((Coice == 0) ? ">> " : " ") + "Вывести базу данных по возрастанию ФИО");
                Console.WriteLine(((Coice == 1) ? ">> " : " ") + "Вывести базу данных по убыванию ФИО");
                Console.WriteLine(((Coice == 2) ? ">> " : " ") + "Вывести базу данных по возрастанию Даты рождения");
                Console.WriteLine(((Coice == 3) ? ">> " : " ") + "Вывести базу данных по убыванию Даты рождения");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Coice == 4) ? ">> " : " ") + "Назад");
                Console.ResetColor();

                key = (int)Console.ReadKey().Key;
                if (key == 38) Coice--;
                if (key == 40) Coice++;
                if (key == 13 || key == 27) break;

                if (Coice < 0) Coice = 4;
                if (Coice > 4) Coice = 0;

            } while (key != 27);

            switch (Coice)
            {
                case 0:
                    Editing = false;
                    ReadListFile(Editing);
                    //q1 - Сортировка по ФИО Возрастающая
                    IEnumerable<Student> q1 = TotalList.OrderBy(sortByName => sortByName.SurName).OrderBy(sortByName => sortByName.Name).OrderBy(sortByName => sortByName.MiddleName);
                    Console.Clear();

                    foreach (Student student in q1)
                    {
                        Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
                    Console.ResetColor();
                    Console.ReadKey();
                    SortElementsByOrderMenu();
                    break;

                case 1:
                    Editing = false;
                    ReadListFile(Editing);
                    //Dq1 - Сортировка по ФИО Убывающая
                    IEnumerable<Student> Dq1 = TotalList.OrderByDescending(DsortByName => DsortByName.SurName).OrderByDescending(DsortByName => DsortByName.Name).OrderByDescending(DsortByName => DsortByName.MiddleName);
                    Console.Clear();

                    foreach (Student student in Dq1)
                    {
                        Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                    }
                    TotalList.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
                    Console.ResetColor();
                    Console.ReadKey();
                    SortElementsByOrderMenu();
                    break;

                case 2:
                    Editing = false;
                    ReadListFile(Editing);
                    //q2 - Сортировка по Дате Рождения Возрастающая
                    IEnumerable<Student> q2 = TotalList.OrderBy(sortByDate => sortByDate.BirthDayDate.Remove(0,6)).OrderBy(sortByDate => sortByDate.BirthDayDate.Remove(4, 3).Remove(0, 3)).OrderBy(sortByDate => sortByDate.BirthDayDate.Remove(1, 7)); //01.03.02
                    Console.Clear();

                    foreach (Student student in q2)
                    {
                        Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                    }
                    TotalList.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
                    Console.ResetColor();
                    Console.ReadKey();
                    SortElementsByOrderMenu();
                    break;

                case 3:
                    Editing = false;
                    ReadListFile(Editing);
                    //Dq2 - Сортировка по Дате Рождения Убывающая
                    IEnumerable<Student> Dq2 = TotalList.OrderByDescending(DsortByDate => DsortByDate.BirthDayDate.Remove(0, 6)).OrderByDescending(DsortByDate => DsortByDate.BirthDayDate.Remove(4, 3).Remove(0, 3)).OrderByDescending(DsortByDate => DsortByDate.BirthDayDate.Remove(1, 7)); //01.03.02
                    Console.Clear();

                    foreach (Student student in Dq2)
                    {
                        Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                    }
                    TotalList.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
                    Console.ResetColor();
                    Console.ReadKey();
                    SortElementsByOrderMenu();
                    break;

                case 4:
                    Console.Clear();
                    EditorMenu();
                    break;
            }
        }
        private void AddElement()
        {
            ReadListFile(true);
            string SurName, Name, MiddleName, BDDate, Institute, Group;
            int Course;
            double avgscore;
            Console.Title = "Редактор добавления студента";

            // Фамилия
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите Фамилию студента");
                SurName = Console.ReadLine();

                if (Regex.Match(SurName, "[a-zA-Z0-9]").Value.Length > 0 || SurName.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    SurName = SurName.Substring(0, 1).ToUpper() + SurName.Remove(1, SurName.Length - 1) + SurName.Substring(1).ToLower().Replace(" ", "");
                    break;
                }
            }

            // Имя
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Введите Имя студента");
                Name = Console.ReadLine();


                if (Regex.Match(Name, "[a-zA-Z0-9]").Value.Length > 0 || Name.Length<2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Name = Name.Substring(0, 1).ToUpper() + Name.Remove(1, Name.Length - 1) + Name.Substring(1).ToLower().Replace(" ", "");
                    break;
                }
            }

            // Отчество
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите Отчество студента");
                MiddleName = Console.ReadLine();

                if (Regex.Match(MiddleName, "[a-zA-Z0-9]").Value.Length > 0 || MiddleName.Length<2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    MiddleName = MiddleName.Substring(0, 1).ToUpper() + MiddleName.Remove(1, MiddleName.Length - 1) + MiddleName.Substring(1).ToLower().Replace(" ", "");
                    break;
                }
            }

            int _day, _month, _year;
            string day = "", month = "", year = "";
            // Дата рождения день
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите сначала День рождения студента");
                bool Approved = int.TryParse(Console.ReadLine(), out _day);
                if (!Approved || _day < 1 || _day > 31)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такое значение не подходит для дня");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    if (_day.ToString().Length == 1)
                        day = "0" + _day.ToString();
                    else
                        day = _day.ToString();
                    break;
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите Месяц рождения студента");
                bool Approved = int.TryParse(Console.ReadLine(), out _month);
                if (!Approved || _month < 1 || _month > 12)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такое значение не подходит для месяца");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    if (_month.ToString().Length == 1)
                        month = "0" + _month.ToString();
                    else
                        month = _month.ToString();
                    break;
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите Год рождения студента");
                bool Approved = int.TryParse(Console.ReadLine(), out _year);
                if (!Approved || _year.ToString().Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такое значение не подходит для года");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    if (_year.ToString().Length > 2)
                        _year = int.Parse(_year.ToString().Remove(1, 2));
                    year = _year.ToString();
                    break;
                }
            }
            BDDate = $"{day}.{month}.{year}";

            // Название института
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите Институт студента");
                Institute = Console.ReadLine();
                Institute = Institute.ToUpper();
                if (Regex.Match(Institute, "[a-zA-Z0-9]").Value.Length > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В названии института не может быть чисел и английских символов");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                {
                    Institute.ToUpper();
                    break;
                }
            }
             
            //Группа
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите группу студента (Пример: БПИ20-9)");
                Group = Console.ReadLine();
                Group = Group.ToUpper().Replace(" ","");
                if (Regex.Match(Group, "[a-zA-Z]").Value.Length > 0 || Regex.Match(Group, "[0-9]").Value.Length < 1  || !Group.Contains('-'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                    break;
            }

            //Курс
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите курс студента");
                bool Approved = int.TryParse(Console.ReadLine(), out Course);
                if (!Approved || Course < 1 || Course > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такое значение не соответствует курсу студента");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else  
                    break;
            }

            //Ср.знач
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите ср.знач оценки студента");
                bool Approved = double.TryParse(Console.ReadLine(), out avgscore);
                if (!Approved || avgscore < 1 || avgscore > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такое значение не подходит для средней оценки студента");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else
                    break;
            }

            //Подтверждение
            while (true) {
                Console.Clear();
                Console.WriteLine("Вы хотите добавить студента: ");
                Console.Write("{0} {1} {2} | {3} | {4} {5} | Курс:{6} | Средний балл: {7:C1} ? \nY - Сохранить, E - изменить данные", SurName, Name, MiddleName, BDDate, Institute, Group, Course, avgscore);
                int key = (int)Console.ReadKey().Key;
                if (key == 89)
                {
                    try {
                        Console.Clear();
                        TotalList.Add(new Student(TotalList.Count, SurName, Name, MiddleName, BDDate, Institute, Group, Course, avgscore));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Студент успешно добавлен!");
                        Console.ResetColor();
                        WorkWithFileRaw Save = new WorkWithFileRaw();
                        Save.WriteInFileRaw(TotalList);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\nНажмите любую клавишу для продолжения");
                        Console.ResetColor();
                        Console.ReadKey();
                        EditorMenu();
                        break;
                    }
                    catch 
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Студент не был добавлен!");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\nНажмите любую клавишу для продолжения");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                if (key == 69)
                {
                    int _case;
                    bool Editing = true;
                    while (Editing) 
                    {
                        Console.Clear();
                        Console.WriteLine("Что вы хотите изменить у {0} {1} {2} | {3} | {4} {5} | Курс:{6} | Средний балл: {7} ?", SurName, Name, MiddleName, BDDate, Institute, Group, Course, avgscore);
                        Console.WriteLine("1. Фамилия" +
                            "\n2. Имя" +
                            "\n3. Отчество" +
                            "\n4. День рождения" +
                            "\n5. Название института" +
                            "\n6. Группу" +
                            "\n7. Курс" +
                            "\n8. Средний балл" +
                            "\n9. Отменить редактирование");
                        bool Approved = int.TryParse(Console.ReadLine(), out _case);

                        if (Approved && _case < 8 && _case > 1) 
                        { 
                            switch (_case)
                            {
                                case 1:

                                    // Фамилия
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Фамилию студента");
                                        SurName = Console.ReadLine();

                                        if (Regex.Match(SurName, "[a-zA-Z0-9]").Value.Length > 0 || SurName.Length < 2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            SurName = SurName.Substring(0, 1).ToUpper() + SurName.Remove(1, SurName.Length - 1) + SurName.Substring(1).ToLower().Replace(" ", "");
                                            break;
                                        }
                                    }
                                    break;

                                case 2:

                                    // Имя
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Имя студента");
                                        Name = Console.ReadLine();


                                        if (Regex.Match(Name, "[a-zA-Z0-9]").Value.Length > 0 || Name.Length < 2)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Name = Name.Substring(0, 1).ToUpper() + Name.Remove(1, Name.Length - 1) + Name.Substring(1).ToLower().Replace(" ", "");
                                            break;
                                        }
                                    }
                                    break;

                                case 3:

                                    // Отчество
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Отчество студента");
                                        MiddleName = Console.ReadLine();
                                        MiddleName = MiddleName.Remove(1, MiddleName.Length - 1) + MiddleName.Substring(1).ToLower().Replace(" ", "");

                                        if (Regex.Match(MiddleName, "[a-zA-Z0-9]").Value.Length > 0 || !Name.StartsWith(Regex.Match(Name, "[А-Я]").ToString()) || MiddleName.Contains(' '))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                            break;
                                    }
                                    break;

                                case 4:

                                    // Дата рождения день
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите сначала День рождения студента");
                                        Approved = int.TryParse(Console.ReadLine(), out _day);
                                        if (!Approved || _day < 1 || _day > 31)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Такое значение не подходит для дня");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            if (_day.ToString().Length == 1)
                                                day = "0" + _day.ToString();
                                            else
                                                day = _day.ToString();
                                            break;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Месяц рождения студента");
                                        Approved = int.TryParse(Console.ReadLine(), out _month);
                                        if (!Approved || _month < 1 || _month > 12)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Такое значение не подходит для месяца");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            if (_month.ToString().Length == 1)
                                                month = "0" + _month.ToString();
                                            else
                                                month = _month.ToString();
                                            break;
                                        }
                                    }
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Год рождения студента");
                                        Approved = int.TryParse(Console.ReadLine(), out _year);
                                        if (!Approved || _year.ToString().Length != 4)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Такое значение не подходит для года");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            if (_year.ToString().Length > 2)
                                                _year = int.Parse(_year.ToString().Remove(1, 2));
                                            year = _year.ToString();
                                            break;
                                        }
                                    }
                                    BDDate = $"{day}.{month}.{year}";
                                    break;

                                case 5:

                                    // Название института
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите Институт студента");
                                        Institute = Console.ReadLine();
                                        Institute = Institute.ToUpper();
                                        if (Regex.Match(Institute, "[a-zA-Z0-9]").Value.Length > 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("В названии института не может быть чисел и английских символов");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Institute.ToUpper();
                                            break;
                                        }
                                    }
                                    break;

                                case 6:

                                    //Группа
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите группу студента (Пример: БПИ20-9)");
                                        Group = Console.ReadLine();
                                        Group = Group.ToUpper().Replace(" ", "");
                                        if (Regex.Match(Group, "[a-zA-Z]").Value.Length > 0 || Regex.Match(Group, "[0-9]").Value.Length < 1 || !Group.Contains('-'))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                            break;
                                    }
                                    break;

                                case 7:

                                    //Курс
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите курс студента");
                                        Approved = int.TryParse(Console.ReadLine(), out Course);
                                        if (!Approved || Course < 1 || Course > 5)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Такое значение не соответствует курсу студента");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                            break;
                                    }
                                    break;

                                case 8:

                                    //Ср.знач
                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введите ср.знач оценки студента");
                                        Approved = double.TryParse(Console.ReadLine(), out avgscore);
                                        if (!Approved || avgscore < 1 || avgscore > 5)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Такое значение не подходит для средней оценки студента");
                                            Console.ResetColor();
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                        }
                                        else
                                            break;
                                    }
                                    break;
                            }
                        }
                        else if (_case == 9)
                        {
                            Console.Clear();
                            Editing = false;
                            break;
                        }
                            
                    } 
                }
                if (key == 27)
                {
                    Console.Clear();
                    EditorMenu();
                }
            }
        }
        private void EditElement()
        {
            ReadListFile(false);
            string SurName, Name, MiddleName, Institute, Group;
            int Course,_case;
            double avgscore;
            bool Editing = true;
            Console.Title = "Редактор изменений информации о студентах";
            int PlaceOfStudent=0;

            while (true) {
                Console.Clear();
                foreach (Student student in TotalList)
                {
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                }
                Console.Write("Выберите, какому студенту по номеру следует изменить информацию: ");
                bool Approved = int.TryParse(Console.ReadLine(), out PlaceOfStudent);
                if (!Approved || PlaceOfStudent > TotalList.Count || PlaceOfStudent < 1)
                {
                    GotExeption(2, "Номер не может превышать общее кол-во элементов или быть меньше 1", "Введите существующий элемент");
                }
                else
                    break;
            }
            while (Editing)
            {
                WorkWithFileRaw Save = new WorkWithFileRaw();
                Console.Clear();
                Console.WriteLine("Что вы хотите изменить у {0} {1} {2} | {3} | {4} {5} | Курс:{6} | Средний балл: {7} ?", TotalList[PlaceOfStudent-1].SurName, TotalList[PlaceOfStudent - 1].Name, TotalList[PlaceOfStudent - 1].MiddleName, TotalList[PlaceOfStudent - 1].BirthDayDate, TotalList[PlaceOfStudent - 1].Institute, TotalList[PlaceOfStudent - 1].Group, TotalList[PlaceOfStudent - 1].Cource, TotalList[PlaceOfStudent - 1].AverageScore);
                Console.WriteLine("1. Фамилия" +
                    "\n2. Имя" +
                    "\n3. Отчество" +
                    "\n4. День рождения" +
                    "\n5. Название института" +
                    "\n6. Группу" +
                    "\n7. Курс" +
                    "\n8. Средний балл" +
                    "\n9. Отменить редактирование");
                bool Approved = int.TryParse(Console.ReadLine(), out _case);
                if (Approved && _case < 8 && _case > 0)
                {
                    switch (_case)
                    {
                        case 1:

                            // Фамилия
                            while (true)
                            {
                                SurName = "";
                                Console.Clear();
                                Console.WriteLine("Введите Фамилию студента");
                                SurName = Console.ReadLine();

                                if (Regex.Match(SurName, "[a-zA-Z0-9]").Value.Length > 0 || SurName.Length < 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent-1].SurName = SurName.Substring(0, 1).ToUpper() + SurName.Substring(1).ToLower();
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 2:

                            // Имя
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите Имя студента");
                                Name = Console.ReadLine();


                                if (Regex.Match(Name, "[a-zA-Z0-9]").Value.Length > 0 || Name.Length < 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].Name = Name.Substring(0, 1).ToUpper() + Name.Remove(1, Name.Length - 1) + Name.Substring(1).ToLower().Replace(" ", "");
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 3:

                            // Отчество
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите Отчество студента");
                                MiddleName = Console.ReadLine();

                                if (Regex.Match(MiddleName, "[a-zA-Z0-9]").Value.Length > 0 || !MiddleName.StartsWith(Regex.Match(MiddleName, "[А-Я]").ToString()) || MiddleName.Contains(' '))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].MiddleName = MiddleName.Remove(1, MiddleName.Length - 1) + MiddleName.Substring(1).ToLower().Replace(" ", "");
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 4:
                            int _day, _month, _year;
                            string day = "", month = "", year = "";
                            // Дата рождения день
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите сначала День рождения студента");
                                Approved = int.TryParse(Console.ReadLine(), out _day);
                                if (!Approved || _day < 1 || _day > 31)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такое значение не подходит для дня");
                                    Console.ResetColor();
                                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    if (_day.ToString().Length == 1)
                                        day = "0" + _day.ToString();
                                    else
                                        day = _day.ToString();
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите Месяц рождения студента");
                                Approved = int.TryParse(Console.ReadLine(), out _month);
                                if (!Approved || _month < 1 || _month > 12)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такое значение не подходит для месяца");
                                    Console.ResetColor();
                                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    if (_month.ToString().Length == 1)
                                        month = "0" + _month.ToString();
                                    else
                                        month = _month.ToString();
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите Год рождения студента");
                                Approved = int.TryParse(Console.ReadLine(), out _year);
                                if (!Approved || _year.ToString().Length != 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такое значение не подходит для года");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    if (_year.ToString().Length > 2)
                                        _year = int.Parse(_year.ToString().Remove(1, 2));
                                    year = _year.ToString();
                                    break;
                                }
                            }
                            TotalList[PlaceOfStudent - 1].BirthDayDate = $"{day}.{month}.{year}";
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 5:

                            // Название института
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите Институт студента");
                                Institute = Console.ReadLine();
                                if (Regex.Match(Institute, "[a-zA-Z0-9]").Value.Length > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("В названии института не может быть чисел и английских символов");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].Institute = Institute.ToUpper();
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 6:

                            //Группа
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите группу студента (Пример: БПИ20-9)");
                                Group = Console.ReadLine();
                                Group = Group.ToUpper().Replace(" ", "");
                                if (Regex.Match(Group, "[a-zA-Z]").Value.Length > 0 || Regex.Match(Group, "[0-9]").Value.Length < 1 || !Group.Contains('-'))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].Group = Group;
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 7:

                            //Курс
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите курс студента");
                                Approved = int.TryParse(Console.ReadLine(), out Course);
                                if (!Approved || Course < 1 || Course > 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такое значение не соответствует курсу студента");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].Cource = Course;
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;

                        case 8:

                            //Ср.знач
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Введите ср.знач оценки студента");
                                Approved = double.TryParse(Console.ReadLine(), out avgscore);
                                if (!Approved || avgscore < 1 || avgscore > 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Такое значение не подходит для средней оценки студента");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    TotalList[PlaceOfStudent - 1].AverageScore = avgscore;
                                    break;
                                }
                            }
                            Save.WriteInFileRaw(TotalList);
                            break;
                    }
                }
                else if (_case == 9)
                {
                    Console.Clear();
                    Editing = false;
                    EditElement();
                }

            }
        }
        private void DeleteElement()
        {
            ReadListFile(false);
            WorkWithFileRaw Save = new WorkWithFileRaw();
            Console.Title = "Удаление студента из Базы данных";
            int PlaceOfStudent;
            while (true)
            {
                Console.Clear();
                foreach (Student student in TotalList)
                {
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                }
                Console.Write("Выберите, какого студента нужнор удалить из базы данных ");
                bool Approved = int.TryParse(Console.ReadLine(), out PlaceOfStudent);
                if (!Approved || PlaceOfStudent > TotalList.Count || PlaceOfStudent < 1)
                {
                    GotExeption(2, "Номер не может превышать общее кол-во элементов или быть меньше 1", "Введите существующий элемент");
                }
                else
                    break;
            }
            Console.Clear();
            Console.Write("{0} {1} {2} | {3} | {4} {5} | Курс:{6} | Средний балл: {7:C1} ? \nY - Удалить, n - Отменить", TotalList[PlaceOfStudent-1].SurName, TotalList[PlaceOfStudent-1].Name, TotalList[PlaceOfStudent - 1].MiddleName, TotalList[PlaceOfStudent - 1].BirthDayDate, TotalList[PlaceOfStudent - 1].Institute, TotalList[PlaceOfStudent - 1].Group, TotalList[PlaceOfStudent - 1].Cource, TotalList[PlaceOfStudent - 1].AverageScore);
            int key = (int)Console.ReadKey().Key;
            if (key == 89)
            {
                Console.Clear();
                TotalList.RemoveAt(PlaceOfStudent - 1);
                Save.WriteInFileRaw(TotalList);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Студент успешно удален из БД!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ResetColor();
                Console.ReadKey();
                EditorMenu();
            }
            if (key == 78)
                DeleteElement();
            if (key == 27)
                EditorMenu();
        }
        //----------------------------------------------//

        //-----------------OUTPUTMENU-------------------//
        private void OutputMenu()
        {
            Console.Title = "Меню вывода элементов";
            int Coice = 0, key;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Меню вывода и поиска");
                Console.ResetColor();
                Console.WriteLine(((Coice == 0) ? ">> " : " ") + "Найти студента по ФИО");
                Console.WriteLine(((Coice == 1) ? ">> " : " ") + "Найти студента по ДАТЕ РОЖДЕНИЯ");
                Console.WriteLine(((Coice == 2) ? ">> " : " ") + "Найти среднее значение и сумму по полю СРЕДНИЙ БАЛЛ");
                Console.WriteLine(((Coice == 3) ? ">> " : " ") + "Найти Максимальное и Минимальное значение СРЕДНЕГО БАЛЛА");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Coice == 4) ? ">> " : " ") + "Назад");
                Console.ResetColor();

                key = (int)Console.ReadKey().Key;
                if (key == 38) Coice--;
                if (key == 40) Coice++;
                if (key == 13 || key == 27) break;

                if (Coice < 0) Coice = 4;
                if (Coice > 4) Coice = 0;

            } while (key != 27);

            switch (Coice)
            {
                case 0:
                    Console.Clear();
                    FindByName();
                    break;

                case 1:
                    Console.Clear();
                    FindByDate();
                    break;

                case 2:
                    Console.Clear();
                    FindAverage();
                    break;

                case 3:
                    Console.Clear();
                    FindAverageMinMax();
                    break;

                case 4:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }

        private void FindByName()
        {
            Console.Title = "Поиск совпадений по ФИО";
            bool HaveCoincidence = false;
            ReadListFile(false);
            Console.WriteLine("По какому имени/фамилии/отчеству ищем?");
            string Coincidence = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Поиск совпадений...\n");
            System.Threading.Thread.Sleep(200);
            foreach (Student student in TotalList)
            {
                if((student.SurName + student.Name + student.MiddleName).ToUpper().Contains(Coincidence.ToUpper())) 
                {
                    HaveCoincidence = true;
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}", 
                        student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                }
            }

            if (!HaveCoincidence)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("К сожалению, в Базе данных нет такого студента, в чьем име\\фамилии\\отчестве содержалось бы {0}", Coincidence);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.ResetColor();
            Console.ReadKey();
            OutputMenu();
        }

        private void FindByDate()
        {
            Console.Title = "Поиск совпадений по Дате рождения";
            bool HaveCoincidence = false;
            ReadListFile(false);
            Console.WriteLine("По какой дате ищем? /Пример ввода: 01.03.02");
            string Coincidence = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Поиск совпадений...\n");
            System.Threading.Thread.Sleep(200);
            foreach (Student student in TotalList)
            {
                if (student.BirthDayDate.Contains(Coincidence))
                {
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}",
                        student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                    HaveCoincidence = true;
                }
            }

            if (!HaveCoincidence)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("К сожалению, в Базе данных нет такого студента, у которого дата рождения {0}", Coincidence);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.ResetColor();
            Console.ReadKey();
            OutputMenu();
        }

        private void FindAverage()
        {
            ReadListFile(false);
            double AVG = 0;
            Console.Title = "Поиск среднего значения";
            Console.WriteLine("Ищем среднее значение по полю Средний балл\n");
            foreach (Student student in TotalList)
            {
                AVG += student.AverageScore;
            }
            AVG = AVG / TotalList.Count();
            Console.WriteLine("Среднее значение равно: {0:C1}", AVG);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nНажмите любую клавишу для продолжения");
            Console.ResetColor();
            Console.ReadKey();
            OutputMenu();
        }

        private void FindAverageMinMax()
        {
            ReadListFile(false);
            double min = double.MaxValue, max = double.MinValue;
            Console.Title = "Поиск Min Max элементов по полю Средний балл";
            Console.WriteLine("Ищем Min Max значение по полю Средний балл\n");
            foreach (Student student in TotalList)
            {
                if (min > student.AverageScore)
                    min = student.AverageScore;

                if (max < student.AverageScore)
                    max = student.AverageScore;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Ищем студентов с самым низким средним баллом\n");
            Console.ResetColor();
            foreach (Student student in TotalList)
            {
                if (student.AverageScore == min)
                {
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}",
                        student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nИщем студентов с самым высоким средним баллом\n");
            Console.ResetColor();
            foreach (Student student in TotalList)
            {
                if (student.AverageScore == max)
                {
                    Console.WriteLine("№{0}| {1} {2} {3} | {4} | {5} {6} | Курс:{7} | Средний балл: {8}",
                        student.PlaceInList, student.SurName, student.Name, student.MiddleName, student.BirthDayDate, student.Institute, student.Group, student.Cource, student.AverageScore);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\nНажмите любую клавишу для продолжения");
            Console.ResetColor();

            Console.ReadKey();
            OutputMenu();
        }

        //----------------------------------------------//
        #endregion
        public void ReadListFile(bool IsEditing)
        {
            WorkWithFileRaw WWFR = new WorkWithFileRaw();
            WWFR.ReadFromFileRaw(TotalList, IsEditing);//Добавить всех студентов в список студентов
        }
    }
}