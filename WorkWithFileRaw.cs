using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab2_DB
{
    class WorkWithFileRaw
    {
        Functions function = new Functions();
        public void ReadFromFileRaw(List<Student> list, bool IsAdding)
        {
            list.Clear();
            int CurrenLineNum = 0;
            string SurName, Name, MiddleName, BDDate, Institute, Group;
            int Place, Course;
            double avgscore;
            string[] ReadenLines = {""};
            string defaultpath = @"DataBase\StudentsBD.txt";
            try { 
                ReadenLines = File.ReadAllLines(defaultpath);
            }
            catch { 
                    function.ExeptionDefaultOutput(3, "В файле не было найдено ни единого элемента","Введите элементы");
            }
            //Добавляем из прочитанного файла Студентов в главный общий лист
            try
            { 
                for (int i = 0; i < ReadenLines.Length; i++)
                {
                    CurrenLineNum = i;
                    string CurrentLine = ReadenLines[i];
                    string[] words = CurrentLine.Split(' ');

                    bool Approved = int.TryParse(words[0], out Place);
                    if (!Approved)
                        function.ExeptionDefaultOutput(3, $"В графе Номер {words[0]} на строке {CurrenLineNum + 1} допущена ошибка. ", "\nУберите буквы и/или поставьте значение от 1 до 5");

                    SurName = words[1];
                    Name = words[2];
                    MiddleName = words[3];
                    if (Regex.Match(SurName+Name+MiddleName, "[a-zA-Z]").Value.Length > 0 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе ФИО {SurName+" "+Name+" "+MiddleName} на строке {CurrenLineNum + 1} допущена ошибка. ","\nУберите лишние буквы");

                    BDDate = words[4];
                    if (Regex.Match(BDDate, "[а-яА-ЯёЁa-zA-Z]").Value.Length > 0 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе Дата {words[4]} на строке {CurrenLineNum + 1} допущена ошибка. ", "\nУберите лишние буквы");

                    Institute = words[5].ToUpper();
                    if (Regex.Match(Institute, "[a-zA-Z0-9]").Value.Length > 0 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе Институт {words[5]} на строке {CurrenLineNum + 1} допущена ошибка. ", "\nУберите лишние буквы");

                    Group = words[6].ToUpper();
                    if (!Group.Contains('-') || Group.Contains(' ') || Regex.Match(Group, "[a-zA-Z]").Value.Length > 0 || Regex.Match(Group, "[0-9]").Value.Length < 0 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе Группа {words[6]} на строке {CurrenLineNum + 1} допущена ошибка. ", "Посмотрите шаблон, название группы должно быть слитно с числами\nПример: БПИ20-9");

                    Approved = int.TryParse(words[7], out Course);
                    if (!Approved||Course<1 || Course>5 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе Курс {words[7]} на строке {CurrenLineNum + 1} допущена ошибка. ", "\nУберите буквы и/или поставьте значение от 1 до 5");

                    Approved = double.TryParse(words[8], out avgscore);
                    if (!Approved || avgscore < 0 || avgscore > 5 && IsAdding == false)
                        function.ExeptionDefaultOutput(3, $"В графе Средний балл {words[8]} на строке {CurrenLineNum + 1} допущена ошибка. ", "\nУберите буквы и/или поставьте значение от 1 до 5");

                    list.Add(new Student(Place, SurName, Name, MiddleName, BDDate, Institute, Group, Course, avgscore));
                }
            }
            catch
            {
                function.ExeptionDefaultOutput(3, $"Ошибка в записи файла.\nОшибка в строке {CurrenLineNum+1}", 
                    "\nШаблон\n{Номер} Фамилия Имя Отчество {день}.{месяц}.{год} {Институт} {группа} {Курс} *,* \n\nПример правильного написания\n1 Иванов Иван Иванович 01.02.98 ИТАСУ БПИ20-5 1 4,3");
            }
        }
        public void WriteInFileRaw(List<Student> list)
        {
            string defaultpath = @"DataBase\StudentsBD.txt";
            string[] AllStudents = new string[list.Count];

            int counter=0;
            foreach (Student std in list)
            {
                AllStudents[counter] = ((counter+1)+" "+std.SurName + " " + std.Name + " " + std.MiddleName + " " + std.BirthDayDate + " " + std.Institute + " " + std.Group + " " + std.Cource + " " + std.AverageScore).ToString();
                counter++;
            }
            File.WriteAllLines(defaultpath, AllStudents);
        }
    }
}
