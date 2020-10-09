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
        public void ExeptionDefaultPutput(int half, string Exeption)
        {
            if(half == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ResetColor();
                Console.ReadKey();
            }
            if(half == 2) { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Exeption);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nНажмите любую клавишу для продолжения");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
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
        private void InputInStudentEdits(bool OperatingWithNumbers, int _case, List<Student> list, int place, string WhatWeNeedToInput, string ExeptionOutPut)
        {
            WorkWithFileRaw Save = new WorkWithFileRaw();
            if (!OperatingWithNumbers)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(WhatWeNeedToInput);
                    string Input = Console.ReadLine();

                    if (Regex.Match(Input, "[a-zA-Z0-9]").Value.Length > 0 || Input.Length < 2)
                    {
                        ExeptionDefaultPutput(2, ExeptionOutPut);
                    }
                    else
                    {
                        switch (_case)
                        {
                            case 1: //Фамилия
                                list[place - 1].SurName = Input.Substring(0, 1).ToUpper() + Input.Substring(1).ToLower().Replace(" ", "");
                                break;

                            case 2: //Имя
                                list[place - 1].Name = Input.Substring(0, 1).ToUpper() + Input.Substring(1).ToLower().Replace(" ", "");
                                break;

                            case 3: //Отчество
                                list[place - 1].MiddleName = Input.Substring(0, 1).ToUpper() + Input.Substring(1).ToLower().Replace(" ", "");
                                break;

                            case 4: //Институт
                                list[place - 1].Institute = Input.ToUpper();
                                break;

                            case 5: //Группа
                                TotalList[place - 1].Group = Input;
                                break;

                            default:
                                GotExeption(1, "Не удалось изменить значение", "Обратитесь к разработчику");
                                break;
                        }

                        break;
                    }
                }
            }
            else
            {
                switch (_case)
                {
                    case 1://Дата рождения
                        int _day, _month, _year;
                        string day = "", month = "", year = "";
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите сначала День рождения студента");
                            bool Approved = int.TryParse(Console.ReadLine(), out _day);
                            if (!Approved || _day < 1 || _day > 31)
                            {
                                ExeptionDefaultPutput(2, "Такое значение не подходит для дня");
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
                                ExeptionDefaultPutput(2, "Такое значение не подходит для месяца");
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
                                ExeptionDefaultPutput(2, "Такое значение не подходит для года");
                            }
                            else
                            {
                                if (_year.ToString().Length > 2)
                                    _year = int.Parse(_year.ToString().Remove(1, 2));
                                year = _year.ToString();
                                break;
                            }
                        }
                        list[place - 1].BirthDayDate = $"{day}.{month}.{year}";
                        break;

                    case 2://Курс
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите курс студента");
                            bool Approved = int.TryParse(Console.ReadLine(), out int Course);
                            if (!Approved || Course < 1 || Course > 5)
                            {
                                ExeptionDefaultPutput(2, "Такое значение не соответствует курсу студента");
                            }
                            else
                            {
                                list[place - 1].Cource = Course;
                                break;
                            }
                        }
                        break;

                    case 3://Средний балл
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите ср.знач оценки студента");
                            bool Approved = double.TryParse(Console.ReadLine(), out double avgscore);
                            if (!Approved || avgscore < 1 || avgscore > 5)
                            {
                                ExeptionDefaultPutput(2, "Такое значение не подходит для средней оценки студента");
                            }
                            else
                            {
                                list[place - 1].AverageScore = avgscore;
                                break;
                            }
                        }
                        break;

                    default:
                        GotExeption(1, "Не удалось изменить значение", "Обратитесь к разработчику");
                        break;
                }
            }
            Save.WriteInFileRaw(list);
        }

        #region VisualMenus
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
        }

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
            int Choice = 0, key;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Меню сортировки");
                Console.ResetColor();
                Console.WriteLine(((Choice == 0) ? ">> " : " ") + "Вывести базу данных по возрастанию ФИО");
                Console.WriteLine(((Choice == 1) ? ">> " : " ") + "Вывести базу данных по убыванию ФИО");
                Console.WriteLine(((Choice == 2) ? ">> " : " ") + "Вывести базу данных по возрастанию Даты рождения");
                Console.WriteLine(((Choice == 3) ? ">> " : " ") + "Вывести базу данных по убыванию Даты рождения");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Choice == 4) ? ">> " : " ") + "Назад");
                Console.ResetColor();

                key = (int)Console.ReadKey().Key;
                if (key == 38) Choice--;
                if (key == 40) Choice++;
                if (key == 13 || key == 27) break;

                if (Choice < 0) Choice = 4;
                if (Choice > 4) Choice = 0;

            } while (key != 13);

            if (key == 27) Choice = 4;

            switch (Choice)
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
                    ExeptionDefaultPutput(1, "------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
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
                    ExeptionDefaultPutput(1, "------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
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
                    ExeptionDefaultPutput(1, "------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
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
                    ExeptionDefaultPutput(1, "------------------------------------------------------------------\nНажмите любую клавишу, чтобы продолжить");
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
                    ExeptionDefaultPutput(2,"В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел");
                else
                {
                    SurName = SurName.Substring(0, 1).ToUpper() + SurName.Substring(0).ToLower().Replace(" ", "");
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
                    ExeptionDefaultPutput(2, "В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел");
                else
                {
                    Name = Name.Substring(0, 1).ToUpper() + Name.Substring(0).ToLower().Replace(" ", "");
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
                    ExeptionDefaultPutput(2,"В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел");
                else
                {
                    MiddleName = MiddleName.Substring(0, 1).ToUpper() + MiddleName.Substring(0).ToLower().Replace(" ", "");
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
                    ExeptionDefaultPutput(2, "Такое значение не подходит для дня");
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
                    ExeptionDefaultPutput(2, "Такое значение не подходит для месяца");
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
                    ExeptionDefaultPutput(2, "Такое значение не подходит для года");
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
                    ExeptionDefaultPutput(2, "В названии института не может быть чисел и английских символов");
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
                    ExeptionDefaultPutput(2, "В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
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
                    ExeptionDefaultPutput(2, "Такое значение не соответствует курсу студента");
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
                    ExeptionDefaultPutput(2, "Такое значение не подходит для среднего балла студента");
                else
                    break;
            }

            //Подтверждение
            while (true) {
                Console.Clear();
                Console.WriteLine("Вы хотите добавить студента: ");
                Console.Write("{0} {1} {2} | {3} | {4} {5} | Курс:{6} | Средний балл: {7:C1} ? \nY - Сохранить, n - отменить добавление", SurName, Name, MiddleName, BDDate, Institute, Group, Course, avgscore);
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
                        ExeptionDefaultPutput(2, "Студент не был добавлен!");
                    }
                }
                if (key == 27 || key == 78)
                {
                    Console.Clear();
                    EditorMenu();
                }
            }
        }
        private void EditElement()
        {
            ReadListFile(false);
            int _case;
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
                            //Введите Фамилию студента | 2,"В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел"
                            InputInStudentEdits(false, 1, TotalList, PlaceOfStudent, "Введите Фамилию студента", "В фамилии первая буква должна быть заглавной, а сама фамилия не должно иметь английских символов или чисел");
                            break;

                        case 2:

                            // Имя
                            // Введите Имя студента | В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел
                            InputInStudentEdits(false, 2, TotalList, PlaceOfStudent, "Введите Имя студента", "В имени первая буква должна быть заглавной, а само имя не должно иметь английских символов или чисел");
                            break;

                        case 3:

                            // Отчество
                            // Введите Отчество студента | В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел
                            InputInStudentEdits(false, 3, TotalList, PlaceOfStudent, "Введите Отчество студента", "В отчестве первая буква должна быть заглавной, а само отчество не должно иметь английских символов или чисел");
                            break;

                        case 4:
                            InputInStudentEdits(true, 1, TotalList, PlaceOfStudent, "", "");
                            break;

                        case 5:

                            // Название института
                            // Введите Институт студента | В названии института не может быть чисел и английских символов
                            InputInStudentEdits(false, 4, TotalList, PlaceOfStudent, "Введите Институт студента", "В названии института не может быть чисел и английских символов");
                            break;

                        case 6:
                            /*
                                if (Regex.Match(Group, "[a-zA-Z]").Value.Length > 0 || Regex.Match(Group, "[0-9]").Value.Length < 1 || !Group.Contains('-'))
                                {
                                    ExeptionDefaultPutput(2,"В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
                                }
                             */
                            //Группа
                            //Введите группу студента (Пример: БПИ20-9) | В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной
                            InputInStudentEdits(false, 5, TotalList, PlaceOfStudent, "/Введите группу студента (Пример: БПИ20-9)", "В названии группы не может английских символов, пробелов, а также нужна '-', но не более одной");
                            break;

                        case 7:

                            //Курс
                            InputInStudentEdits(true, 2, TotalList, PlaceOfStudent, "", "");
                            break;

                        case 8:

                            //Ср.знач
                            InputInStudentEdits(true, 3, TotalList, PlaceOfStudent, "", "");
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
            int Choice = 0, key;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Меню вывода и поиска");
                Console.ResetColor();
                Console.WriteLine(((Choice == 0) ? ">> " : " ") + "Найти студента по ФИО");
                Console.WriteLine(((Choice == 1) ? ">> " : " ") + "Найти студента по ДАТЕ РОЖДЕНИЯ");
                Console.WriteLine(((Choice == 2) ? ">> " : " ") + "Найти среднее значение и сумму по полю СРЕДНИЙ БАЛЛ");
                Console.WriteLine(((Choice == 3) ? ">> " : " ") + "Найти Максимальное и Минимальное значение СРЕДНЕГО БАЛЛА");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(((Choice == 4) ? ">> " : " ") + "Назад");
                Console.ResetColor();

                key = (int)Console.ReadKey().Key;
                if (key == 38) Choice--;
                if (key == 40) Choice++;
                if (key == 13 || key == 27) break;

                if (Choice < 0) Choice = 4;
                if (Choice > 4) Choice = 0;

            } while (key != 13);
            if (key == 27) Choice = 4;
            switch (Choice)
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
            ExeptionDefaultPutput(1, "");
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
            ExeptionDefaultPutput(1, "");
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
            ExeptionDefaultPutput(1, "");
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
            ExeptionDefaultPutput(1, "");
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